using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAnnuaireClient.Models;

public class Site
{
    public int Id { get; set; } // identifiant unique du site
    public string Ville { get; set; } // ville du site
    public ICollection<Salarie>? Salaries { get; set; }
}
