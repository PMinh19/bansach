using Microsoft.EntityFrameworkCore;
using BanSach.Components.Data;

using BanSach.Components.IService;
using BanSach.Components.Model;

namespace BanSach.Components.Services
{
    public class ItemManagement : IItemManagement
    {
        private readonly AppDbContext db;
        public ItemManagement(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<List<Product>> GetAllItem()
        {
            return await db.Products.ToListAsync();
        }
        public async Task<Product> CreateItem(Product Product)
        {
            // Thêm Product vào cơ sở dữ liệu
            db.Products.Add(Product);
            await db.SaveChangesAsync();
            return Product; // Trả về đối tượng Product đã thêm
        }

        public async Task DeleteItem(Product Product)
        {
            db.Products.Remove(Product);
            await db.SaveChangesAsync();
        }

        public async Task EditItem(Product Product)
        {
            db.Products.Update(Product);
            await db.SaveChangesAsync();
        }
        public async Task<Product> GetItemById(int ProductId)
        {
            return await db.Products.FirstOrDefaultAsync(p => p.ProductId == ProductId);
        }
        public async Task<List<Category>> GetAllCategogy()
        {
            return await db.Categories.ToListAsync();
        }
    }
}
