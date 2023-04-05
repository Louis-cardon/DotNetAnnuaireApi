namespace DotNetAnnuaireApi.Services
{
    using DotNetAnnuaireApi.Models;
    using System.Collections.Generic;

    public interface ISiteService
    {
        IEnumerable<Site> GetAllSites();
        Site GetSiteById(int id);
        void AddSite(Site site);
        void UpdateSite(Site site);
        void DeleteSite(int id);
    }
}
