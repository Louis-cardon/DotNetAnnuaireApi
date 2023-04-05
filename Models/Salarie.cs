﻿namespace DotNetAnnuaireApi.Models
{
    // Classe représentant un salarié
    public class Salarie
    {
        public int Id { get; set; } // identifiant unique du salarié
        public string Nom { get; set; } // nom du salarié
        public string Prenom { get; set; } // prénom du salarié
        public string TelephoneFixe { get; set; } // numéro de téléphone fixe du salarié
        public string TelephonePortable { get; set; } // numéro de téléphone portable du salarié
        public string Email { get; set; } // adresse email du salarié
        public Service Service { get; set; } // service associé au salarié
        public Site Site { get; set; } // site associé au salarié
    }
}
