using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinPoints
{
    [ApiController]
    [Route("markers")]
    public class MarkersController : ControllerBase
    {
        private readonly ILogger<MarkersController> _logger;

        private readonly IRepositoryManager _irepositorymanager;

        public MarkersController
            (
            ILogger<MarkersController> logger,
            IRepositoryManager irepositorymanager
            )
        {
            _logger = logger;
            _irepositorymanager = irepositorymanager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateData(MarkerProperties data)
        {
            if (ModelState.IsValid)
            {
                /*data.Id = new int();*/

                await _irepositorymanager.Markers.Add(data);
                await _irepositorymanager.CompleteAsync();

                return CreatedAtAction("GetItem", new { data.Id }, data);

            }
            return StatusCode(500, "Something went wrong");
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {  
               var markers = await _irepositorymanager.Markers.All();
               return Ok(markers);
            
        }
    }
}
