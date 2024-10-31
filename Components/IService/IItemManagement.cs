using BanSach.Components.Model;

namespace BanSach.Components.IService
{
    public interface IItemManagement
    {
        Task<List<Product>> GetAllItem();
        Task<Product> CreateItem(Product Product);
        Task DeleteItem(Product Product);
        Task EditItem(Product Product);
        Task<Product?> GetItemById(int ProductId);
        Task<List<Category>> GetAllCategogy();
    }
}
