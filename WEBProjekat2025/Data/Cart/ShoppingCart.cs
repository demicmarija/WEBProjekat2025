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

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            var context = services.GetService<appDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
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


        public async Task ClearShoppingCartAsync() 
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
             _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
