using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WEBProjekat2025.Data.Cart;

namespace WEBProjekat2025.Data.ViewComponents
{
    
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
             _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
           
            return View(items.Count());
        }
    }
}
