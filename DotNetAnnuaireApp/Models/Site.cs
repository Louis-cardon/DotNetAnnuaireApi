using System.ComponentModel.DataAnnotations;

namespace DotNetAnnuaireApp.Models
{
    // Classe représentant un site
    public class Site
    {
        public int Id { get; set; } // identifiant unique du site
        public string Ville { get; set; } // ville du site
        public ICollection<Salarie>? Salaries { get; set; }
    }
}
