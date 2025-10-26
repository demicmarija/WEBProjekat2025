using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBProjekat2025.Data.Base;
using System.Collections.Generic;

namespace WEBProjekat2025.Models
{
    public class Aroma : IEntityBase
    {
        [Key]
        public int Id{get; set;}

        //[NotMapped]
        //public int Id {
        //    get => AromaId;
        //    set => AromaId = value;
        //}

        [Display(Name = "Slika")]
        [Required(ErrorMessage = "Slika se zahteva")]
        public string SlikaURL { get; set; }

        [Display(Name = "Puno Ime")]
        [Required(ErrorMessage = "Puno ime se zahteva")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Ime mora biti izmedju 3 i 40 karaktera")]
        public string Ime { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Opis se zahteva")]
        public string Opis { get; set; }

        [ValidateNever]
        public List<Arome_Pice> Arome_Pice { get; set; }

        //public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}