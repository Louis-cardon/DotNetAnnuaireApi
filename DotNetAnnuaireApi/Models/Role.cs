﻿using System.ComponentModel.DataAnnotations;

namespace DotNetAnnuaireApi.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; } // identifiant unique du rôle
        public string Nom { get; set; } // nom du rôle
        public ICollection<Salarie>? Salaries { get; set; } // liste des salariés ayant ce rôle
    }

}
