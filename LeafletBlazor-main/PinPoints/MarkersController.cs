using Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Schema;
using Shared.DataTransferObjects;
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
        public async Task<ActionResult<int>> CreateData(MarkerProperties newmarker)
        {
                await _irepositorymanager.Markers.Add(newmarker);
                await _irepositorymanager.CompleteAsync();
                //return CreatedAtAction("GetItem", new { newmarker.Id }, newmarker);
                return newmarker.Id;
           
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {  
               var markers = await _irepositorymanager.Markers.All();
               return Ok(markers);
            
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetItem(int Id)
        {
            var markers = await _irepositorymanager.Markers.GetById(Id);
            if (markers == null)
                return NotFound();
            return Ok(markers);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int Id)
        {
            var item = await _irepositorymanager.Markers.GetById(Id);
            if (item == null)
                return NotFound();
            await _irepositorymanager.Markers.Delete(Id);
            await _irepositorymanager.CompleteAsync();

            return Ok(Id);
        }
    }
}
