using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using api.Modelos;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet("{id}")] // Un objeto con identificado (llave id)
        public ActionResult<Blog> GetBlogs([FromRoute]int id){

            Blog resultado = db.Blogs.Find(id);
            if(resultado == null){
                return NotFound(); //404
            }
            return Ok(resultado);
        }
        
       [HttpPost]
       public IActionResult crearBlog([FromBody] Blog objBlog){
           //validar si existe, retornar un httpcode
            if(!ModelState.IsValid){
                return BadRequest();
            }
           db.Blogs.Add(objBlog);
           db.SaveChanges();//commit sobre la DB

           return Ok();
            
        }
        //http://localhost:5000/api/Blogs/1
        //[HttpDelete("{id}")]
        [Route("~/api/Blogs/{id}")]
        [HttpDelete]
        public ActionResult eliminarDatos(int id){
            Blog existe = db.Blogs.Find(id);
            if(existe == null){
                return NotFound(); //404
            }
            db.Blogs.Remove(existe);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult editarBlog([FromRoute] int id, [FromBody] Blog objBlog){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if(id != objBlog.Id){
                return BadRequest(ModelState);
            }
            Blog existe = db.Blogs.Find(id);
            if(existe == null){
                return NotFound(); //404
            }
            db.Entry(id).State = EntityState.Modified;
            db.Update(objBlog);
            db.SaveChanges();
            return Ok();
        }
    }

}
