using System.ComponentModel.DataAnnotations;

namespace DotNetAnnuaireApp.Models
{
    public class Role
    {
        public int Id { get; set; } // identifiant unique du rôle
        public string Nom { get; set; } // nom du rôle
        public ICollection<Salarie>? Salaries { get; set; } // liste des salariés ayant ce rôle
    }

}
