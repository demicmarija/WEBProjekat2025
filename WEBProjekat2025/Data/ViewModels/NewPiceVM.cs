
using System.ComponentModel.DataAnnotations;
using WEBProjekat2025.Data.Enum;

namespace WEBProjekat2025.Data.ViewModels
{
    public class NewPiceVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        [Display(Name = "Ime pića")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Opis je obavezan")]
        [Display(Name = "Opis pića")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Cena je obavezna")]
        [Display(Name = "Cena pića")]
        public double Cena { get; set; }

        [Required(ErrorMessage = "Slika je obavezna")]
        [Display(Name = "Slika pića")]
        public string SlikaURL { get; set; }



        [Required(ErrorMessage = "Diskont je obavezan")]
        [Display(Name = "Diskont")]
        public int DiskontId { get; set; }

        [Required(ErrorMessage = "Aroma je obavezna")]
        [Display(Name = "Izaberite aromu")]
        public List<int> AromeIds { get; set; }

        [Required(ErrorMessage = "Proizvođač je obavezan")]
        [Display(Name = "Proizvođač pića")]
        public int ProizvodjacId { get; set; }

        [Required(ErrorMessage = "Datum proizvodnje je obavezan")]
        [Display(Name = "Datum proizvodnje")]
        [DataType(DataType.Date)]
        public DateTime Proizvedeno { get; set; }

        [Required(ErrorMessage = "Kategorija je obavezna")]
        [Display(Name = "Kategorija pića")]
        public KategorijaPica KategorijaPica { get; set; }
    }
}