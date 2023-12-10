using CernadasFragueiroIvanTarea4.Servicios;
using Microsoft.AspNetCore.Mvc;
using CernadasFragueiroIvanTarea4.Models;
using System.Drawing;
using System;
using System.Collections.Generic;

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
            var alturas = await repositorioPokemons.ObtenerAlturas();
            var pesos = await repositorioPokemons.ObtenerPesos();
            var tipos = await repositorioPokemons.ObtenerTipoPokemon();

            var viewModel = new ListaPokemonViewModel
            {
                Pokemons = pokemons,
                Alturas = alturas,
                Pesos = pesos,
                Tipos = tipos
            };


            return View("Lista",viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Filtrar(ListaPokemonViewModel listaPokemonViewModel) 
        {
            ListaPokemonViewModel nuevaListaPokemonViewModel = new ListaPokemonViewModel();

            IEnumerable<Pokemon> filtroAltura = new List<Pokemon>();
            IEnumerable<Pokemon> filtroPeso = new List<Pokemon>();
            IEnumerable<Pokemon> filtroTipo = new List<Pokemon>();
            IEnumerable<Pokemon> listaFiltrada = new List<Pokemon>();
            
            if (!(listaPokemonViewModel.altura == 0))
            {
                filtroAltura = await repositorioPokemons.FiltarAltura(listaPokemonViewModel.altura);
            }
            else
            {
                filtroAltura = await repositorioPokemons.ObtenerPokemons();
            }
            
            if(!(listaPokemonViewModel.peso == 0))
            {
                filtroPeso = await repositorioPokemons.FiltrarPeso(listaPokemonViewModel.peso);
            }
            else
            {
                filtroPeso = await repositorioPokemons.ObtenerPokemons();
            }
            if (!(listaPokemonViewModel.tipo == "0"))
            {
                filtroTipo = await repositorioPokemons.FiltrarTipo(listaPokemonViewModel.tipo);
            }
            else 
            {
                filtroTipo = await repositorioPokemons.ObtenerPokemons();
            }

            listaFiltrada = filtroAltura
            .Join(filtroPeso, objeto => objeto.numero_pokedex, otroObjeto => otroObjeto.numero_pokedex, (objeto, otroObjeto) => objeto)
            .Join(filtroTipo, objeto => objeto.numero_pokedex, otroObjeto => otroObjeto.numero_pokedex, (objeto, otroObjeto) => objeto);

            var alturas = await repositorioPokemons.ObtenerAlturas();
            var pesos = await repositorioPokemons.ObtenerPesos();
            var tipos = await repositorioPokemons.ObtenerTipoPokemon();

            var viewModel = new ListaPokemonViewModel
            {
                Pokemons = listaFiltrada,
                Alturas = alturas,
                Pesos = pesos,
                Tipos = tipos
            };


            return View("Lista", viewModel);
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
