using System.ComponentModel.DataAnnotations;
using System;

namespace api.Modelos 
{
    public class Post
    {
        [Key]
        public int postId { get; set; }

        [Required(ErrorMessage="Debe ingresar el nombre del autor.")]
        [DataType(DataType.Text)]
        public string creador { get; set; }

        public string titulo { get; set; }
        public string contenido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
    }
}