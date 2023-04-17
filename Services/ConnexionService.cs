using DotNetAnnuaireApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAnnuaireApi.Services
{
    public class ConnexionService : IConnexionService
    {
        private readonly AnnuaireContext _context;

        public ConnexionService(AnnuaireContext context)
        {
            _context = context;
        }

        public async Task<Salarie> ConnexionAsync(string email, string motDePasse)
        {
            var salarie = await _context.Salaries.Where(s => s.Email == email).Include(s=> s.Role).SingleOrDefaultAsync();

            if (salarie == null)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(motDePasse, salarie.MotDePasse))
            {
                return null;
            }

            return salarie;
        }

    }
}
