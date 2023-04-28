using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAnnuaireClient.Models;

public class Service
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public ICollection<Salarie>? Salaries { get; set; }
}
