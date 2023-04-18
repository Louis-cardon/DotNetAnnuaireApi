using DotNetAnnuaireApi.Models;

namespace DotNetAnnuaireApi.Services
{
    public interface IConnexionService
    {
        Task<Salarie> ConnexionAsync(string email, string motDePasse);
    }
}
