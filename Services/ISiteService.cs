namespace DotNetAnnuaireApi.Services
{
    using DotNetAnnuaireApi.Models;
    using System.Collections.Generic;

    public interface ISiteService
    {
        Task<List<Site>> GetAllSitesAsync();
        Task<Site> GetSiteByIdAsync(int id);
        Task<Site> AddSiteAsync(Site site);
        Task UpdateSiteAsync(Site site);
        Task DeleteSiteAsync(int id);
    }
}
