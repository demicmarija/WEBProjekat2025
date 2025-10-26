using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace WEBProjekat2025.Models
{
    public class ShoppingCartItem
    {
        [Key]

        public int Id { get; set; }

        public Pice Pice { get; set; }

        public int Kolicina { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
