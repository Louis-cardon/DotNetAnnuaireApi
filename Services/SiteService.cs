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

            public IEnumerable<Site> GetAllSites()
            {
                return _context.Sites.Include(s => s.Salaries).ToList();
            }

            public Site GetSiteById(int id)
            {
                return _context.Sites.Include(s => s.Salaries).FirstOrDefault(s => s.Id == id);
            }

            public void AddSite(Site site)
            {
                _context.Sites.Add(site);
                _context.SaveChanges();
            }

            public void UpdateSite(Site site)
            {
                _context.Sites.Update(site);
                _context.SaveChanges();
            }

            public void DeleteSite(int id)
            {
                var site = _context.Sites.FirstOrDefault(s => s.Id == id);
                if (site != null)
                {
                    _context.Sites.Remove(site);
                    _context.SaveChanges();
                }
            }

        }
}
