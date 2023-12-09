using System.ComponentModel.DataAnnotations;

namespace CernadasFragueiroIvanTarea4.Models
{
    public class Movimiento
    {
        [Key]
        [Required]
        public int id_movimiento { get; set; }
        [Required]
        [StringLength(20)]
        public string nombre { get; set; }
        [Required]
        public int potencia { get; set; }
        [Required]
        public int precision_mov { get; set; }
        [Required]
        [StringLength(500)]
        public string descripcion { get; set; }
        [Required]
        public int pp { get; set; }
        [Required]
        public int id_tipo { get; set; }
        [Required]
        public int prioridad { get; set; }
    }
}
