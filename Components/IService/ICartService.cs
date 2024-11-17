//using BanSach.Components.Model;
//namespace BanSach.Components.IService
//{
//    public interface ICartService
//    {

//        //client
//        event Action OnChange;
//        Task AddToCart(Product_cart productCart);
//        Task<List<Product_cart>> GetCartProducts();
//        Task RemoveProductFromCart(int productId);
//        Task UpdateQuantity(Product_cart productCart);
//        Task StoreCartItems(bool emptyLocalCart);
//        Task GetCartItemsCount();




//        //server
//        Task<ServiceResponse<List<Product_cart>>> GetCartProducts(List<Product_cart> cartItems);
//        Task<ServiceResponse<List<Product_cart>>> StoreCartItems(List<Product_cart> cartItems);
//        Task<ServiceResponse<int>> GetCartItemsCount(int userId);
//        Task<ServiceResponse<List<Product_cart>>> GetDbCartProducts(int userId);
//        Task<ServiceResponse<bool>> AddProductToCart(Product_cart productCart);
//        Task<ServiceResponse<bool>> UpdateProductQuantity(Product_cart productCart);
//        Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int userId);
//    }
//}
using BanSach.Components.Model;
using System.Threading.Tasks;

namespace BanSach.Components.IService
{
    public interface ICartService
    {
        Task<List<Product_cart>> GetAllPCart();
        Task<Product_cart> CreatePCart(Product_cart Product_cart);
        Task DeletePCart(Product_cart Product_cart);
    }
}
