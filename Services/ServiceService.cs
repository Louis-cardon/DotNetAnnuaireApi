using DotNetAnnuaireApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DotNetAnnuaireApi.Services
{
    public class ServiceService : IServiceService
    {
        private readonly AnnuaireContext _dbContext;

        public ServiceService(AnnuaireContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await _dbContext.Services.ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _dbContext.Services.FindAsync(id);
        }

        public async Task<Service> AddServiceAsync(Service service)
        {
            _dbContext.Services.Add(service);
            await _dbContext.SaveChangesAsync();
            return service;
        }

        public async Task UpdateServiceAsync(Service service)
        {
            var elem = await _dbContext.Services.FindAsync(service.Id);
            if (elem != null)
            {
                elem.Nom = service.Nom;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _dbContext.Services.FindAsync(id);
            if (service != null)
            {
                _dbContext.Services.Remove(service);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
