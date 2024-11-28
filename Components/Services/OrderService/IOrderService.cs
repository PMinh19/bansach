using BanSach.Components.Model;

namespace BanSach.Components.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<Bill>> GetOrdersByUserIdAsync(int userId);
    }
}
