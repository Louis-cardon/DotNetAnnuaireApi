namespace DotNetAnnuaireApi.Controllers
{
    using System.Collections.Generic;
    using DotNetAnnuaireApi.Models;
    using DotNetAnnuaireApi.Services;
    using Microsoft.AspNetCore.Mvc;


    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var services = _serviceService.GetAllServices();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var service = _serviceService.GetServiceById(id);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }

            _serviceService.AddService(service);

            return CreatedAtAction(nameof(Get), new { id = service.Id }, service);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Service service)
        {
            if (service == null || id != service.Id)
            {
                return BadRequest();
            }

            var existingService = _serviceService.GetServiceById(id);

            if (existingService == null)
            {
                return NotFound();
            }

            _serviceService.UpdateService(service);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var service = _serviceService.GetServiceById(id);

            if (service == null)
            {
                return NotFound();
            }

            _serviceService.DeleteService(id);

            return NoContent();
        }
    }
}
