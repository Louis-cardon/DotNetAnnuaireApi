using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetAnnuaireApi.Models;
using DotNetAnnuaireApi.Services;
using Microsoft.AspNetCore.Authentication;

namespace DotNetAnnuaireApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnexionController : ControllerBase
    {
        private readonly IConnexionService _connexionService;

        public ConnexionController(IConnexionService connexionService)
        {
            _connexionService = connexionService;
        }

        [HttpPost]
        public async Task<IActionResult> Connexion([FromBody] ConnexionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var resultat = await _connexionService.ConnexionAsync(model.Email, model.MotDePasse);

                if (resultat == null)
                {
                    return BadRequest(new { message = "Email ou mot de passe incorrect" });
                }

                return Ok(resultat);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

    public class ConnexionModel
    {
        public string Email { get; set; }
        public string MotDePasse { get; set; }
    }
}
