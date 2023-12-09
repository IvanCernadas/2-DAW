using CernadasFragueiroIvanTarea4.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CernadasFragueiroIvanTarea4.Servicios
{
    public interface IRepositorioPokemons
    {
        Task<string> InvolucionPokemon(int numero_pokedex);
        Task<string> EvolucionPokemon(int pokemon_origen);
        Task<Pokemon> MostrarPokemon(string nombre);
        Task<IEnumerable<Pokemon>> ObtenerPokemons();
        Task<List<Movimiento>> MovimientosPokemon(int numero_pokedex);
    }
    public class RepositorioPokemons : IRepositorioPokemons
    {
        private readonly string connectionString;

        public RepositorioPokemons(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Pokemon>> ObtenerPokemons()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Pokemon>("Select numero_pokedex, nombre, peso, altura from Pokemon");
        }

        public async Task<Pokemon> MostrarPokemon(string nombre) {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Pokemon>(@"Select numero_pokedex, nombre, peso, altura from Pokemon where nombre = @nombre", new { nombre });
        }

        public async Task<string> EvolucionPokemon(int pokemon_origen)
        {
            Pokemon p = new Pokemon();

            using var connection = new SqlConnection(connectionString);


             int num = await connection.QueryFirstOrDefaultAsync<int>(@"select pokemon_evolucionado
                                                                            from pokemon inner join evoluciona_de
                                                                            on pokemon.numero_pokedex = evoluciona_de.pokemon_evolucionado
                                                                            where pokemon_origen = @pokemon_origen", new { pokemon_origen });

            p = await connection.QueryFirstOrDefaultAsync<Pokemon>(@"select nombre from pokemon where numero_pokedex = @num", new { num });

            if (p == null) return "No existe";
            return p.nombre;
        }

        public async Task<string> InvolucionPokemon(int numero_pokedex)
        {
            Pokemon p = new Pokemon();

            using var connection = new SqlConnection(connectionString);

            int numeroPokedexOrigen = await connection.QueryFirstOrDefaultAsync<int>(@"select pokemon_origen
                                                                                from evoluciona_de
                                                                                where pokemon_evolucionado = @numero_pokedex", new { numero_pokedex });

            p = await connection.QueryFirstOrDefaultAsync<Pokemon>(@"select nombre from pokemon where numero_pokedex = @numeroPokedexOrigen", new { numeroPokedexOrigen });

            if (p == null) return "No existe";
            return p.nombre;
        }

        public async Task<List<Movimiento>> MovimientosPokemon(int numero_pokedex)
        { 
            using var connection = new SqlConnection(connectionString);

            return (List<Movimiento>)await connection.QueryAsync<Movimiento>(@"select m.* from pokemon_movimiento_forma as p inner join
                                                                            movimiento as m on p.id_movimiento = m.id_movimiento 
                                                                            where p.numero_pokedex = @numero_pokedex", new { numero_pokedex });
        }
    }
}

