using DotNetAnnuaireApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAnnuaireApi.Services
{
    public class ServiceService : IServiceService
    {
        private readonly AnnuaireContext _dbContext;

        public ServiceService(AnnuaireContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Service> GetAllServices()
        {
            return _dbContext.Services.Include(s => s.Salaries).ToList();
        }

        public Service GetServiceById(int id)
        {
            return _dbContext.Services.Include(s => s.Salaries).FirstOrDefault(s => s.Id == id);
        }

        public void AddService(Service service)
        {
            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();
        }

        public void UpdateService(Service service)
        {
            _dbContext.Services.Update(service);
            _dbContext.SaveChanges();
        }

        public void DeleteService(int id)
        {
            var service = _dbContext.Services.FirstOrDefault(s => s.Id == id);
            if (service != null)
            {
                _dbContext.Services.Remove(service);
                _dbContext.SaveChanges();
            }
        }
    }
}
