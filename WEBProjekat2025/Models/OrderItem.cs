using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProjekat2025.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int Cena { get; set; }

        public int PiceId { get; set; }
        [ForeignKey("PiceId")]

        public  Pice Pice { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]

        public Order Order { get; set; }
    }
}
