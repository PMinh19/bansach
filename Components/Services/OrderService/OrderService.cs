using BanSach.Components.Model;

namespace BanSach.Components.Services.OrderService
{
    public class OrderService: IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Phương thức này lấy các hóa đơn của khách hàng theo UserId
        public async Task<List<Bill>> GetOrdersByUserIdAsync(int userId)
        {
            // Giả sử API có endpoint để lấy hóa đơn theo userId
            var response = await _httpClient.GetFromJsonAsync<List<Bill>>($"api/orders/user/{userId}");
            return response ?? new List<Bill>();
        }
    }
}
