using CernadasFragueiroIvanTarea4.Servicios;
using Microsoft.AspNetCore.Mvc;
using CernadasFragueiroIvanTarea4.Models;

namespace CernadasFragueiroIvanTarea4.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IRepositorioPokemons repositorioPokemons;

        public PokemonController(IRepositorioPokemons repositorioPokemons) 
        {         
            this.repositorioPokemons = repositorioPokemons;
        }

        public async Task<IActionResult> Lista() {

            var pokemons = await repositorioPokemons.ObtenerPokemons();
            List<string> alturas = new List<string>();

        


            return View(pokemons);
        }

        public async Task<IActionResult> Detalles(Pokemon pokemon) {

            List<Movimiento> m = new List<Movimiento>();
            string movimientos="";

            var poke = await repositorioPokemons.MostrarPokemon(pokemon.nombre);
            var evolucion = await repositorioPokemons.EvolucionPokemon(pokemon.numero_pokedex);
            var involucion = await repositorioPokemons.InvolucionPokemon(pokemon.numero_pokedex);
            m = await repositorioPokemons.MovimientosPokemon(pokemon.numero_pokedex);

            foreach (var movimiento in m)
            {
                movimientos += movimiento.nombre;

                if (movimiento != m.Last())
                {
                    movimientos += ", ";
                }
                else 
                { 
                    movimientos += "."; 
                }
            }



            var viewModel = new DetallesPokemonViewModel
            {
                Pokemon = poke,
                Evolucion = evolucion,
                Involucion = involucion,
                Movimiento = movimientos
            };

            return View("Detalles", viewModel);
        }
    }
}
