namespace DotNetAnnuaireApi.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Salarie> Salaries { get; set; }
    }

}
