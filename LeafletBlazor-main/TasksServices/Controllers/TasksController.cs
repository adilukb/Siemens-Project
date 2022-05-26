using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TasksServices.Model;
using TasksServices.Repository;

namespace TasksServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        // GET api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> Get()
        {
            return TasksRepository.Instance.GetTasks();
        }

        // POST: api/tasks
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
