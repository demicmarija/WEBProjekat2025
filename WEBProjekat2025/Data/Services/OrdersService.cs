using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly appDbContext _context;

        public OrdersService (appDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Pice)
            .Where(n => n.UserId == userId).ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAdress
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Kolicina = item.Kolicina,
                    PiceId = item.Pice.Id,
                    OrderId = order.Id,
                    Cena = item.Pice.Cena,
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
