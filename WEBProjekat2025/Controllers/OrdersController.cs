using Microsoft.AspNetCore.Mvc;
using WEBProjekat2025.Data.Cart;
using WEBProjekat2025.Data.Services;
using WEBProjekat2025.Data.ViewModels;

namespace WEBProjekat2025.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IPiceService _piceService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IPiceService piceService, ShoppingCart shoppingCart)
        {
            _piceService = piceService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View();
        }
    }
}
