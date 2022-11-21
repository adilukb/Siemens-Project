/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.PinPoints;

namespace PinPoints.Presentation.Controllers
{
    [ApiController]
    [Route("api/markers")]
    public class MarkersController : ControllerBase
    {
        private readonly ILogger<MarkersController> _logger;

        private readonly IRepositoryManager _irepositorymanager;

        public MarkersController(IServiceManager service)
            => _service = service;

        [HttpGet]
        public IActionResult GetMarkers()
        {
            try
            {
                var markers = _service.MarkersService.GetAllMarkers(trackChanges: false);
                return Ok(markers);
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
*/