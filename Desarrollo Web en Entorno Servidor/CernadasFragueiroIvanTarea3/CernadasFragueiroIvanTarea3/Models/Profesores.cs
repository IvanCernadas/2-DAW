﻿using Microsoft.AspNetCore.Mvc;

namespace CernadasFragueiroIvanTarea3.Models
{
    public class Profesores
    {
       public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Materia { get; set; }
    }
}
