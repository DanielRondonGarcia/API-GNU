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
        public ActionResult<IEnumerable<Blog>> Get()
        {
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
        public ActionResult<Blog> GetBlogs(int categoriaId)
        {
            Blog resultado = db.Blogs.Find(categoriaId);

            if (resultado == null)
            {
                return NotFound(); //404
            }
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult> CrearBlog([FromBody] Blog objetoBlog)
        {
            if (ModelState.IsValid) // saber si los datos que llego está a acorde a lo que necesitamos
            {
                //Validación. para mapearlo en un codigo http acorde a ello            
            }

            var guardado = db.Blogs.Add(objetoBlog);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetBlogs", new { categoriaId = objetoBlog.Id });
        }

        [HttpPut("id")]
        public async Task<ActionResult> EditarBlog([FromBody] int id, [FromBody] Blog objetoBlog)
        {
            if (!ModelState.IsValid) // Controla que sea el tipo de dato que se va a manejar
            {
                return BadRequest(ModelState);
            }

            if (id != objetoBlog.Id) // Controla de que nadie externo haya manipulado los datos
            {
                return BadRequest();
            }

            db.Entry(objetoBlog).State = EntityState.Modified;
            db.Update(objetoBlog);
            await db.SaveChangesAsync();

            return Redirect("Get"); //queda pendiente este return
        }

    }
}