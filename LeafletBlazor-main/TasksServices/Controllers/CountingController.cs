using Microsoft.AspNetCore.Mvc;
using TasksServices.Repository;

namespace TasksServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountingController : ControllerBase
    {
        // GET api/counting
        [HttpGet]
        public void Get()
        {
            
        }

        // GET api/counting/5
        [HttpGet("{id}")]
        public ActionResult<bool> Get(int id)
        {
            return TasksRepository.Instance.HasChildren(id); ;
        }

        // POST api/counting
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/counting/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/counting/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
