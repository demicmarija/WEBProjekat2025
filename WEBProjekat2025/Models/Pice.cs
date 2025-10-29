using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBProjekat2025.Data.Base;
using WEBProjekat2025.Data.Enum;

namespace WEBProjekat2025.Models
{
    public class Pice : IEntityBase
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }


        [Display(Name = "Ime")]
        public string Ime { get; set; }


        [Display(Name = "Opis")]
        public string Opis { get; set; }


        [Display(Name = "Cena")]
        public double Cena { get; set; }



        [Display(Name = "Slika")]
        public string SlikaURL { get; set; }


        
       public DateTime Proizvedeno { get; set; }
        public KategorijaPica KategorijaPica { get; set; }

        //veze 
        public List<Arome_Pice> Arome_Pice { get; set; }

        public int DiskontId { get; set; }
        [ForeignKey("DiskontId")]
        public Diskont Diskont {  get; set; }

        public int ProizvodjacId { get; set; }
        [ForeignKey("ProizvodjacId")]
        public Proizvodjac Proizvodjac { get; set; }




    }
}
