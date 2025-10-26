using WEBProjekat2025.Models;

namespace WEBProjekat2025.Data.ViewModels
{
    public class NewPiceDropDownsVM
    {
        public NewPiceDropDownsVM()
        {
            Proizvodjac = new List<Proizvodjac>();
            Diskont = new List<Diskont>();
            Aroma = new List<Aroma>();
        }
        public List<Proizvodjac> Proizvodjac { get; set; }
        public List<Diskont> Diskont { get; set; }
        public List<Aroma> Aroma { get; set; }
       
    }
}
