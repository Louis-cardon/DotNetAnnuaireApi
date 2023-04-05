namespace DotNetAnnuaireApi.Controllers
{
    using System.Collections.Generic;
    using DotNetAnnuaireApi.Models;
    using DotNetAnnuaireApi.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/sites")]
    public class SiteController : ControllerBase
    {
        private readonly ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        // GET: api/sites
        [HttpGet]
        public ActionResult<IEnumerable<Site>> GetSites()
        {
            var sites = _siteService.GetAllSites();
            return Ok(sites);
        }

        // GET: api/sites/5
        [HttpGet("{id}")]
        public ActionResult<Site> GetSite(int id)
        {
            var site = _siteService.GetSiteById(id);

            if (site == null)
            {
                return NotFound();
            }

            return Ok(site);
        }

        // POST: api/sites
        [HttpPost]
        public ActionResult<Site> PostSite(Site site)
        {
            _siteService.AddSite(site);
            return CreatedAtAction(nameof(GetSite), new { id = site.Id }, site);
        }

        // PUT: api/sites/5
        [HttpPut("{id}")]
        public IActionResult PutSite(int id, Site site)
        {
            if (id != site.Id)
            {
                return BadRequest();
            }

            _siteService.UpdateSite(site);
            return NoContent();
        }

        // DELETE: api/sites/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSite(int id)
        {
            var site = _siteService.GetSiteById(id);

            if (site == null)
            {
                return NotFound();
            }

            _siteService.DeleteSite(id);
            return NoContent();
        }
    }

}
