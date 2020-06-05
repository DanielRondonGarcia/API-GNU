using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //return "value"+id;
            return String.Format("value {0}", id);
            //return "".format(id); // Python
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return String.Format("HttpPost {0}", value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return String.Format("HttpPut {0} y valor {1}", id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return String.Format("HttpDelete {0}", id);
        }
    }
}
