namespace CernadasFragueiroIvanTarea4.Models
{
    public class ListaPokemonViewModel
    {
        public IEnumerable<Pokemon> Pokemons { get; set; }
        public IEnumerable<double> Alturas { get; set; }
        public IEnumerable<double> Pesos { get; set; }
        public IEnumerable<string> Tipos {  get; set; }
    
        public Pokemon pokemon { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }
        public string tipo { get; set; }
    }
}
