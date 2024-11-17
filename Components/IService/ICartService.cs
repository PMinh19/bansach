using BanSach.Components.Model;
using System.Threading.Tasks;

namespace BanSach.Components.IService
{
    public interface ICartService
    {
        Task<List<Product_cart>> GetAllPCart();
        Task<Product_cart> CreatePCart(Product_cart Product_cart);
        Task DeletePCart(Product_cart Product_cart);
        Task<Product_bill> PlaceProductBill(Product_bill productBill);
        Task<Product_bill> GetProductBillById(int productBillId);
    }
}
