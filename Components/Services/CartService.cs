using BanSach.Components.Data;
using BanSach.Components.IService;
using BanSach.Components.Model;
using Microsoft.EntityFrameworkCore;

namespace BanSach.Components.Services
{
    public class CartService : ICartService
    {
        private readonly AppDbContext db;
        private readonly HttpClient http;

        public CartService(AppDbContext _db,HttpClient http)
        {
            db = _db;
            this.http = http;
        }
        public async Task<List<Product_cart>> GetAllPCart()
        {
            return await db.Product_carts.ToListAsync();
        }
        public async Task<Product_cart> CreatePCart(Product_cart Product_cart)
        {
            db.Product_carts.Add(Product_cart);
            await db.SaveChangesAsync();
            return Product_cart;
        }

        public async Task DeletePCart(Product_cart Product_cart)
        {
            db.Product_carts.Remove(Product_cart);
            await db.SaveChangesAsync();
        }

        public async Task<Product_bill> PlaceProductBill(Product_bill productBill)
        {
            db.Product_bills.Add(productBill);
            await db.SaveChangesAsync();
            return productBill;
        }

        public async Task<Product_bill> GetProductBillById(int productBillId)
        {
            var response = await http.GetAsync($"api/productBill/{productBillId}");
            if (response.IsSuccessStatusCode)
            {
                var productBill = await response.Content.ReadFromJsonAsync<Product_bill>();
                return productBill;
            }
            return null;
        }
    }
}
