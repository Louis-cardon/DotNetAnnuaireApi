namespace DotNetAnnuaireApi.Controllers
{
    using System.Collections.Generic;
    using DotNetAnnuaireApi.Models;
    using DotNetAnnuaireApi.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class SiteController : ControllerBase
    {
        private readonly ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        // GET: api/sites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> GetSites()
        {
            var sites = await _siteService.GetAllSitesAsync();
            return Ok(sites);
        }

        // GET: api/sites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Site>> GetSite(int id)
        {
            var site = await _siteService.GetSiteByIdAsync(id);

            if (site == null)
            {
                return NotFound();
            }

            return Ok(site);
        }

        // POST: api/sites
        [HttpPost]
        public async Task<ActionResult<Site>> PostSite([FromBody] Site site)
        {
            if (site == null)
            {
                return BadRequest();
            }

            await _siteService.AddSiteAsync(site);
            return CreatedAtAction(nameof(GetSite), new { id = site.Id }, site);
        }

        // PUT: api/sites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSite(int id, [FromBody] Site site)
        {
            if (site == null || id != site.Id)
            {
                return BadRequest();
            }

            var existingSite = await _siteService.GetSiteByIdAsync(id);

            if (existingSite == null)
            {
                return NotFound();
            }
            await _siteService.UpdateSiteAsync(site);
            return NoContent();
        }

        // DELETE: api/sites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSite(int id)
        {
            var site = await _siteService.GetSiteByIdAsync(id);

            if (site == null)
            {
                return NotFound();
            }

            await _siteService.DeleteSiteAsync(id);
            return NoContent();
        }
    }

}
