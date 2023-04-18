using System.Security.Claims;

namespace DotNetAnnuaireApi.Services
{
    public interface IJwtAuthenticationService
    {

        string GenerateToken(string secret, List<Claim> claims);

    }
}
