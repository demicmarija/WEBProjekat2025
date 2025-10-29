using System.ComponentModel.DataAnnotations;
using WEBProjekat2025.Data.Base;


namespace WEBProjekat2025.Models
{
    public class Proizvodjac : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage ="Logo se zahteva")]
        public string LogoURL { get; set; }

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime se zahteva")]
        public string Ime { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Opis se zahteva")]
        public string Opis { get; set; }

        
        public List<Pice> Pica { get; set; }
        
    }
}
