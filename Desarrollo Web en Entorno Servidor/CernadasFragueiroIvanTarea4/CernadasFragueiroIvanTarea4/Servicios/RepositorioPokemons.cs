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
        Task<IEnumerable<double>> ObtenerAlturas();
        Task<List<Movimiento>> MovimientosPokemon(int numero_pokedex);
        Task<IEnumerable<double>> ObtenerPesos();
        Task<IEnumerable<string>> ObtenerTipoPokemon();
        Task<IEnumerable<Pokemon>> FiltarAltura(double altura);
        Task<IEnumerable<Pokemon>> FiltrarPeso(double peso);
        Task<IEnumerable<Pokemon>> FiltrarTipo(string tipo);
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

        public async Task<IEnumerable<double>> ObtenerAlturas()
        { 
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<double>("select altura from pokemon group by altura order by altura asc");
        }

        public async Task<IEnumerable<double>> ObtenerPesos()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<double>("select peso from pokemon group by peso order by peso asc");
        }

        public async Task<IEnumerable<string>> ObtenerTipoPokemon()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<string>("select nombre from tipo inner join pokemon_tipo on tipo.id_tipo = pokemon_tipo.id_tipo group by nombre");
        }

        public async Task<IEnumerable<string>> ObtenerTipo()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<string>("");
        }

        public async Task<IEnumerable<Pokemon>> FiltarAltura(double altura) 
        { 
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Pokemon>("select * from pokemon where pokemon.altura = @altura", new { altura});
        }

        public async Task<IEnumerable<Pokemon>> FiltrarPeso(double peso)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Pokemon>("select * from pokemon where pokemon.peso = @peso", new { peso });
        }

        public async Task<IEnumerable<Pokemon>> FiltrarTipo(string tipo)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Pokemon>("select p.* from Pokemon as p  inner join pokemon_tipo on p.numero_pokedex = pokemon_tipo.numero_pokedex inner join tipo on tipo.id_tipo = pokemon_tipo.id_tipo where tipo.nombre = @tipo", new { tipo });
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

