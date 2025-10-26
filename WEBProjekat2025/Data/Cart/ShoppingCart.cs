using Microsoft.EntityFrameworkCore;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025.Data.Cart
{
    public class ShoppingCart
    {
        public appDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(appDbContext context)
        {
            _context = context;
        }

        public void AddItemtoCart(Pice pice)
        {
            var shoppingCartItems = _context.ShoppingCartItems.FirstOrDefault(n => n.Pice.Id == pice.Id && n.ShoppingCartId == ShoppingCartId);
        } 

            public void AddItemToCart(Pice pice)
            {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Pice.Id == pice.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Pice = pice,
                    Kolicina = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Kolicina++;
            }
            _context.SaveChanges();
             
        }

        public void RemoveItemFromCart(Pice pice)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Pice.Id == pice.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Kolicina > 1)
                {
                    shoppingCartItem.Kolicina--;
                } else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
                _context.SaveChanges();
            } 
        }



        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Pice).ToList());
        }

        public double GetShoppingCartTotal() 
        {
            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Pice.Cena * n.Kolicina).Sum();
            return total;
        }
    }
}
