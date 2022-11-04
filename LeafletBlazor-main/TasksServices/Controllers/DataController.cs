using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksServices.Interface.IConfiguration;
using TasksServices.Model;

namespace TasksServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public DataController
            (
            ILogger<DataController> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateData(MarkerViewModel data)
        {
            if(ModelState.IsValid)
            {
                /*data.Id = new int();*/

                await _unitOfWork.Markers.Add(data);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetItem", new { data.Id }, data);

            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };

            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var data = await _unitOfWork.Markers.GetById(id);

            if (data == null)
                return NotFound();
            return Ok(data);
        }
    }
}
