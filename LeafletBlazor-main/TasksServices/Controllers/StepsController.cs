using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TasksServices.Model;
using TasksServices.Repository;

namespace TasksServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        // GET api/steps
        [HttpGet]
        public void Get()
        {
            
        }

        // GET api/steps/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TaskModel>> Get(int id)
        {
            return TasksRepository.Instance.GetChildren(id);
        }

        // POST api/steps
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/steps/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/steps/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
