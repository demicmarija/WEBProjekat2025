using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WEBProjekat2025.Data.Cart;
using WEBProjekat2025.Data.Services;
using WEBProjekat2025.Data.ViewModels;

namespace WEBProjekat2025.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IPiceService _piceService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(IPiceService piceService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _piceService = piceService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;


        }

        public async Task<IActionResult> Index()
        {
            string userId = "";

            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
            return View(orders);
        }
        
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public  async Task<IActionResult> AddItemToShoppingCart(int id) 
        {
            var item = await _piceService.GetPiceByIdAsync(id);

            if (item != null) 
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _piceService.GetPiceByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public  async Task<IActionResult> CompleteOrder() 
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAdress = "";

           await _ordersService.StoreOrderAsync(items, userId, userEmailAdress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
