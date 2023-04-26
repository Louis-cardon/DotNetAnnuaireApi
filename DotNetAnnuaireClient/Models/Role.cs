using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAnnuaireClient.Models;

public class Role
{
    public int Id { get; set; } // identifiant unique du rôle
    public string Nom { get; set; } // nom du rôle
    public ICollection<Salarie>? Salaries { get; set; } // liste des salariés ayant ce rôle
}
