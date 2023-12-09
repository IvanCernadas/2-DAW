using Microsoft.AspNetCore.Mvc;

namespace CernadasFragueiroIvanTarea3.Models
{
    public class Estudiantes
    {
       public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Curso { get; set; }
    }
}
