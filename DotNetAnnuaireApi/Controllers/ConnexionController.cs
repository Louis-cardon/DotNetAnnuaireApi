using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetAnnuaireApi.Models;
using DotNetAnnuaireApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetAnnuaireApi.Data;
using Microsoft.Extensions.Options;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace DotNetAnnuaireApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnexionController : ControllerBase
    {
        private readonly IConnexionService _connexionService;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IConfiguration _config;

        public ConnexionController(IConnexionService connexionService, IJwtAuthenticationService JwtAuthenticationService, IConfiguration config)
        {
            _connexionService = connexionService;
            _jwtAuthenticationService = JwtAuthenticationService;
            _config = config;
        }



        [HttpPost]
        public async Task<IActionResult> Login([FromBody] ConnexionModel model)
        {
            var user = await _connexionService.ConnexionAsync(model.Email, model.MotDePasse);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role?.Nom ?? "User")
                };
                var token = _jwtAuthenticationService.GenerateToken(_config["Jwt:Key"], claims);
                return Ok(token);
            }
            return Unauthorized();
        }

        [HttpPost("User")]
        public async Task<ActionResult<Salarie>> LoginUser([FromBody] ConnexionModel model)
        {
            var user = await _connexionService.ConnexionAsync(model.Email, model.MotDePasse);
            if (user != null)
            {
                return Ok(user);
            }
            return Unauthorized();
        }

    }
    public class ConnexionModel
    {
        public string Email { get; set; }
        public string MotDePasse { get; set; }
    }
}
