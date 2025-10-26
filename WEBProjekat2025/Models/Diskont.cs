using System.ComponentModel.DataAnnotations;
using WEBProjekat2025.Data.Base;

namespace WEBProjekat2025.Models
{
    public class Diskont : IEntityBase
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo se zahteva")]
        public string LogoURL { get; set; }

        [Display(Name = "Naziv")]
        [Required(ErrorMessage = "Naziv se zahteva")]
        public string  Naziv { get; set; }

        [Display(Name = "Adresa")]
        [Required(ErrorMessage = "Adresa se zahteva")]
        public string Adresa { get; set; }

        //veze
        public List<Pice> Pica { get; set; }

    }
}
