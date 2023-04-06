using System.ComponentModel.DataAnnotations;

namespace DotNetAnnuaireApi.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Salarie> Salaries { get; set; }
    }

}
