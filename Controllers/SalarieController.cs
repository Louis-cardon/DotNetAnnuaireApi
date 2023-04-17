using DotNetAnnuaireApi.Models;
using DotNetAnnuaireApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetAnnuaireApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SalarieController : ControllerBase
    {
        private readonly ISalarieService _salarieService;

        public SalarieController(ISalarieService salarieService)
        {
            _salarieService = salarieService;
        }

        // GET: api/Salarie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salarie>>> GetSalaries()
        {
            var result = await _salarieService.GetAllSalariesAsync();
            return Ok(result);
        }

        // GET: api/Salarie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salarie>> GetSalarie(int id)
        {
            var salarie = await _salarieService.GetSalarieByIdAsync(id);

            if (salarie == null)
            {
                return NotFound();
            }

            return Ok(salarie);
        }

        // POST: api/Salarie
        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        public async Task<ActionResult<Salarie>> PostSalarie([FromBody] Salarie salarie)
        {
            if (salarie == null)
            {
                return BadRequest();
            }

            await _salarieService.AddSalarieAsync(salarie);

            return CreatedAtAction(nameof(GetSalarie), new { id = salarie.Id }, salarie);
        }

        // PUT: api/Salarie/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrateur")]
        public async Task<IActionResult> UpdateSalarie(int id, [FromBody] Salarie salarie)
        {
            if (salarie == null || id != salarie.Id)
            {
                return BadRequest();
            }

            try
            {
                await _salarieService.UpdateSalarieAsync(salarie);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Salarie/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrateur")]
        public async Task<IActionResult> DeleteSalarie(int id)
        {

            var salarie = await _salarieService.GetSalarieByIdAsync(id);

            if (salarie == null)
            {
                return NotFound();
            }

            try
            {
                await _salarieService.DeleteSalarieAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("nom/{nom}")]
        public async Task<ActionResult<IEnumerable<Salarie>>> GetSalarieByNomAsync(string nom)
        {
            var salaries = await _salarieService.GetSalarieByNomAsync(nom);
            return Ok(salaries);
        }

        [HttpGet("site/{siteId}")]
        public async Task<ActionResult<IEnumerable<Salarie>>> GetSalarieBySiteAsync(int siteId)
        {
            var salaries = await _salarieService.GetSalarieBySiteAsync(siteId);
            return Ok(salaries);
        }

        [HttpGet("service/{serviceId}")]
        public async Task<ActionResult<IEnumerable<Salarie>>> GetSalarieByServiceAsync(int serviceId)
        {
            var salaries = await _salarieService.GetSalarieByServiceAsync(serviceId);
            return Ok(salaries);
        }
    }
}
