namespace DotNetAnnuaireApi.Controllers
{
    using System.Collections.Generic;
    using DotNetAnnuaireApi.Models;
    using DotNetAnnuaireApi.Services;
    using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<IEnumerable<Service>>>GetServices()
        {
            var services = await _serviceService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        public async Task<ActionResult<Service>> PostService([FromBody] Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }

            await _serviceService.AddServiceAsync(service);

            return CreatedAtAction(nameof(GetService), new { id = service.Id }, service);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrateur")]
        public async Task<IActionResult> PutService(int id, [FromBody] Service service)
        {
            if (service == null || id != service.Id)
            {
                return BadRequest();
            }

            var existingService = await _serviceService.GetServiceByIdAsync(id);

            if (existingService == null)
            {
                return NotFound();
            }

            await _serviceService.UpdateServiceAsync(service);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrateur")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            await _serviceService.DeleteServiceAsync(id);

            return NoContent();
        }
    }
}
