using System.ComponentModel.DataAnnotations;

namespace DotNetAnnuaireApp.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Salarie>? Salaries { get; set; }
    }

}
