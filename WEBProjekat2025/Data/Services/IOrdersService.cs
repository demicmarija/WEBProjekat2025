using WEBProjekat2025.Models;

namespace WEBProjekat2025.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);

        
    }
}
