using System;
using System.ComponentModel.DataAnnotations;

namespace api.Modelos 
{
    public class Blog
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Autor { get; set; }
    }
}