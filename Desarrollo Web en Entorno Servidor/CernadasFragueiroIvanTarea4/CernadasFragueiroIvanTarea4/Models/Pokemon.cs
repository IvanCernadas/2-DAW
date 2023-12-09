using System.ComponentModel.DataAnnotations;

namespace CernadasFragueiroIvanTarea4.Models
{
    public class Pokemon
    {
        [Required]
        public int numero_pokedex {  get; set; }
        [Required]
        [StringLength(15)]
        public string nombre { get; set; }
        [Required]
        public double peso { get; set; }
        [Required]
        public double altura { get; set; }
    }
}
