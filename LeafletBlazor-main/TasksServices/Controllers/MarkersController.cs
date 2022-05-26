using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TasksServices.Model;
using TasksServices.Repository;

namespace TasksServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkersController : ControllerBase
    {

        //GET api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<MarkerViewModel>> Get()
        {
            return MarkersRepository.Instance.GetMarkers();
        }

        // GET api/markers/5
        [HttpGet("{pos}")]
        public ActionResult<MarkerViewModel> GetMarkersById(int pos)
        {
            return MarkersRepository.Instance.GetMarker(pos);
        }

        // POST: api/markers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/markers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/markers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

