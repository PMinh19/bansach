using BanSach.Components.Data;
using BanSach.Components.IService;
using BanSach.Components.Model;
using Microsoft.EntityFrameworkCore;

namespace BanSach.Components.Services
{
    public class CartService: ICartService
    {
        private readonly AppDbContext db;
        public CartService(AppDbContext _db)
        {
            db = _db;
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

    }
}
