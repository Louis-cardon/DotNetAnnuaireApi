namespace DotNetAnnuaireApi.Services
{
    using DotNetAnnuaireApi.Models;
    using System.Collections.Generic;

    public interface IServiceService
    {
        Task<List<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task<Service> AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }

}
