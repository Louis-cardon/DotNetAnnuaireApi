using DotNetAnnuaireApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAnnuaireApi.Services
{
    public class SiteService : ISiteService
    {

            private readonly AnnuaireContext _context;

            public SiteService(AnnuaireContext context)
            {
                _context = context;
            }

            public async Task<List<Site>> GetAllSitesAsync()
            {
                return await _context.Sites.ToListAsync();
            }

            public async Task<Site> GetSiteByIdAsync(int id)
            {
                return await _context.Sites.FindAsync(id);
            }

            public async Task<Site> AddSiteAsync(Site site)
            {
                _context.Sites.Add(site);
                await _context.SaveChangesAsync();
                return site;
            }

            public async Task UpdateSiteAsync(Site site)
            {
                _context.Sites.Update(site);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteSiteAsync(int id)
            {
                var site = await _context.Sites.FindAsync(id);
                if (site != null)
                {
                    _context.Sites.Remove(site);
                    await _context.SaveChangesAsync();
                }
            }

        }
}
