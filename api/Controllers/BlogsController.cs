using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using api.Modelos;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // http://localhost:5000/api/blogs
    public class BlogsController : ControllerBase
    {
        protected readonly ApiContext db;

        //Constructor
        public BlogsController(ApiContext context)
        {
            db = context;
        }

        [HttpGet] //Lista de objetos
        public ActionResult<IEnumerable<Blog>> Get(){
            //return new string[] { "value1", "value2" };
            var lista = db.Blogs.ToList();
            return lista;
        }

        //localhost:4564/api/Blogs/1
        // [HttpGet("{id}")] // Un objeto con identificado (llave id)
        // public ActionResult<string> GetBlogs(int id)
        // {

        //    // var resultado = db.Blogs.
        //    return "valor";
        // }
        
        //localhost:5000/api/Blogs/1
        [HttpGet("{categoriaId}")] // Un objeto con identificado (llave id)
        public ActionResult<Blog> GetBlogs(int categoriaId){
            Blog resultado = db.Blogs.Find(categoriaId);

            if(resultado == null){
                return NotFound(); //404
            }
            return Ok(resultado);
        }

        [HttpPost]
        public ActionResult<Blog> CrearBlog([FromBody] Blog objetoBlog)
        {
            if(ModelState.IsValid) // saber si los datos que llego está a acorde a lo que necesitamos
            {
                //Validación. para mapearlo en un codigo http acorde a ello            
            }

            var guardado = db.Blogs.Add(objetoBlog);
            db.SaveChanges();

            return CreatedAtAction("GetBlogs", new { categoriaId = objetoBlog.Id });
        }

    }
}