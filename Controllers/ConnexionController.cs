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

        //[HttpPost]
        //public async Task<IActionResult> Connexion([FromBody] ConnexionModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        var resultat = await _connexionService.ConnexionAsync(model.Email, model.MotDePasse);

        //        if (resultat == null)
        //        {
        //            return BadRequest(new { message = "Email ou mot de passe incorrect" });
        //        }

        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //        var claims = new[]
        //        {
        //        new Claim(ClaimTypes.Email, resultat.Email)
        //        };

        //        var token = new JwtSecurityToken(_jwtSettings.Issuer,
        //          _jwtSettings.Audience,
        //          claims,
        //          expires: DateTime.Now.AddMinutes(2500),
        //          signingCredentials: credentials);

        //        var tok = new JwtSecurityTokenHandler().WriteToken(token);
        //        return Ok(tok);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}

        //[HttpGet("validate-token")]
        //public IActionResult ValidateToken([FromQuery] string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(key),
        //        ValidateIssuer = false,
        //        ValidateAudience = false,
        //        ClockSkew = TimeSpan.Zero
        //    };

        //    try
        //    {
        //        tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
        //        return Ok(new { IsValid = true });
        //    }
        //    catch (Exception)
        //    {
        //        // Vous pouvez ajouter une journalisation des exceptions ici si nécessaire
        //        return Ok(new { IsValid = true });
        //    }
        //    //if (ValidateJwtToken(token))
        //    //{
        //    //    return Ok(new { IsValid = true });
        //    //}
        //    //else
        //    //{
        //    //    return BadRequest(new { IsValid = false });
        //    //}
        //}


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] ConnexionModel model)
        {
            var user = await _connexionService.ConnexionAsync(model.Email, model.MotDePasse);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                };
                var token = _jwtAuthenticationService.GenerateToken(_config["Jwt:Key"], claims);
                return Ok(token);
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
