namespace DotNetAnnuaireApi.Services
{
    using DotNetAnnuaireApi.Models;
    using System.Collections.Generic;

    public interface IServiceService
    {
        IEnumerable<Service> GetAllServices();
        Service GetServiceById(int id);
        void AddService(Service service);
        void UpdateService(Service service);
        void DeleteService(int id);
    }

}
