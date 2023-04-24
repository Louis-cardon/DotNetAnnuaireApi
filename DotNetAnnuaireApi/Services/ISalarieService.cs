using DotNetAnnuaireApi.Models;

namespace DotNetAnnuaireApi.Services
{
    public interface ISalarieService
    {
        Task<IEnumerable<Salarie>> GetAllSalariesAsync();
        Task<Salarie> GetSalarieByIdAsync(int id);
        Task<Salarie> AddSalarieAsync(Salarie Salarie);
        Task UpdateSalarieAsync(Salarie Salarie);
        Task DeleteSalarieAsync(int id);


        Task<IEnumerable<Salarie>> GetSalarieByNomAsync(string nom);
        Task<IEnumerable<Salarie>> GetSalarieBySiteAsync(int siteId);
        Task<IEnumerable<Salarie>> GetSalarieByServiceAsync(int serviceId);
    }
}
