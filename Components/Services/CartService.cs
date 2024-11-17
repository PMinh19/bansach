//using Blazored.LocalStorage;
//using BanSach.Components.Model;
//using BanSach.Components.IService;
//using BanSach.Components.Services.AuthService;
//using BanSach.Components.Data;
//using Microsoft.EntityFrameworkCore;

//namespace BanSach.Components.Services.CartService
//{
//    public class CartService : ICartService
//    {
//        private readonly ILocalStorageService localStorage;
//        private readonly HttpClient http;
//        private readonly AppDbContext context;
//        private readonly IAuthService authService;

//        public CartService(ILocalStorageService localStorage, HttpClient http,AppDbContext context,
//            IAuthService authService)
//        {
//            this.localStorage = localStorage;
//            this.http = http;
//            this.context = context;
//            this.authService = authService;
//        }
////client
//        public event Action OnChange;



//        public async Task AddToCart(Product_cart productCart)
//        {
//            if (await authService.IsUserAuthenticated())
//            {
//                await http.PostAsJsonAsync("api/cart/add", productCart);
//            }
//            else
//            {
//                var cart = await localStorage.GetItemAsync<List<Product_cart>>("cart");
//                if (cart == null)
//                {
//                    cart = new List<Product_cart>();
//                }

//                var sameItem = cart.Find(x => x.ProductId == productCart.ProductId);
//                if (sameItem == null)
//                {
//                    cart.Add(productCart);
//                }
//                else
//                {
//                    sameItem.Quantity += productCart.Quantity;
//                }

//                await localStorage.SetItemAsync("cart", cart);
//            }
//            await GetCartItemsCount();
//        }

//        public async Task GetCartItemsCount()
//        {
//            if (await authService.IsUserAuthenticated())
//            {
//                var result = await http.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
//                var count = result.Data;

//                await localStorage.SetItemAsync<int>("cartItemsCount", count);
//            }
//            else
//            {
//                var cart = await localStorage.GetItemAsync<List<Product_cart>>("cart");
//                await localStorage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
//            }

//            OnChange.Invoke();
//        }



//        public async Task<List<Product_cart>> GetCartProducts()
//        {
//            if (await authService.IsUserAuthenticated())
//            {
//                var response = await http.GetFromJsonAsync<ServiceResponse<List<Product_cart>>>("api/cart");
//                return response.Data;
//            }
//            else
//            {
//                var cartItems = await localStorage.GetItemAsync<List<Product_cart>>("cart");
//                return cartItems ?? new List<Product_cart>();
//            }
//        }



//        public async Task RemoveProductFromCart(int productId)
//        {
//            if (await authService.IsUserAuthenticated())
//            {
//                await http.DeleteAsync($"api/cart/{productId}");
//            }
//            else
//            {
//                var cart = await localStorage.GetItemAsync<List<Product_cart>>("cart");
//                if (cart == null) return;

//                var cartItem = cart.Find(x => x.ProductId == productId);
//                if (cartItem != null)
//                {
//                    cart.Remove(cartItem);
//                    await localStorage.SetItemAsync("cart", cart);
//                }
//            }
//        }

//        public async Task StoreCartItems(bool emptyLocalCart = false)
//        {
//            var localCart = await localStorage.GetItemAsync<List<Product_cart>>("cart");
//            if (localCart == null)
//            {
//                return;
//            }

//            await http.PostAsJsonAsync("api/cart", localCart);

//            if (emptyLocalCart)
//            {
//                await localStorage.RemoveItemAsync("cart");
//            }
//        }



//        public async Task UpdateQuantity(Product_cart productCart)
//        {
//            if (await authService.IsUserAuthenticated())
//            {
//                await http.PutAsJsonAsync("api/cart/update-quantity", productCart);
//            }
//            else
//            {
//                var cart = await localStorage.GetItemAsync<List<Product_cart>>("cart");
//                if (cart == null)
//                {
//                    return;
//                }

//                var cartItem = cart.Find(x => x.ProductId == productCart.ProductId);
//                if (cartItem != null)
//                {
//                    cartItem.Quantity = productCart.Quantity;
//                    await localStorage.SetItemAsync("cart", cart);
//                }
//            }
//        }











//        //server
//        public async Task<ServiceResponse<int>> GetCartItemsCount(int userId)
//        {
//            var response = new ServiceResponse<int>();
//            try
//            {

//                int count = await context.Product_carts
//                    .Where(pc => pc.UserId == userId)
//                    .SumAsync(pc => pc.Quantity);

//                response.Data = count;
//                response.Success = true;
//                response.Message = "Successfully retrieved cart item count.";
//            }
//            catch (Exception ex)
//            {

//                response.Data = 0;
//                response.Success = false;
//                response.Message = $"An error occurred: {ex.Message}";
//            }

//            return response;
//        }
//        // Lấy danh sách sản phẩm trong giỏ hàng
//        public async Task<ServiceResponse<List<Product_cart>>> GetCartProducts(List<Product_cart> cartItems)
//        {
//            var response = new ServiceResponse<List<Product_cart>>();
//            try
//            {
//                response.Data = await context.Product_carts
//                    .Where(pc => cartItems.Select(ci => ci.ProductId).Contains(pc.ProductId))
//                    .ToListAsync();
//                response.Success = true;
//            }
//            catch (Exception ex)
//            {
//                response.Data = null;
//                response.Success = false;
//                response.Message = $"An error occurred: {ex.Message}";
//            }

//            return response;
//        }

//        // Lấy danh sách sản phẩm trong giỏ hàng từ cơ sở dữ liệu
//        public async Task<ServiceResponse<List<Product_cart>>> GetDbCartProducts(int userId)
//        {
//            var response = new ServiceResponse<List<Product_cart>>();
//            try
//            {
//                response.Data = await context.Product_carts
//                    .Where(pc => pc.UserId == userId)
//                    .ToListAsync();
//                response.Success = true;
//            }
//            catch (Exception ex)
//            {
//                response.Data = null;
//                response.Success = false;
//                response.Message = $"An error occurred: {ex.Message}";
//            }

//            return response;
//        }

//        // Xóa sản phẩm khỏi giỏ hàng
//        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int userId)
//        {
//            var response = new ServiceResponse<bool>();
//            try
//            {
//                var cartItem = await context.Product_carts
//                    .FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.UserId == userId);

//                if (cartItem != null)
//                {
//                    context.Product_carts.Remove(cartItem);
//                    await context.SaveChangesAsync();
//                    response.Data = true;
//                    response.Success = true;
//                    response.Message = "Product removed successfully.";
//                }
//                else
//                {
//                    response.Data = false;
//                    response.Success = false;
//                    response.Message = "Product not found in cart.";
//                }
//            }
//            catch (Exception ex)
//            {
//                response.Data = false;
//                response.Success = false;
//                response.Message = $"An error occurred: {ex.Message}";
//            }

//            return response;
//        }

//        // Lưu sản phẩm vào giỏ hàng
//        public async Task<ServiceResponse<List<Product_cart>>> StoreCartItems(List<Product_cart> cartItems)
//        {
//            var response = new ServiceResponse<List<Product_cart>>();
//            try
//            {
//                foreach (var item in cartItems)
//                {
//                    var existingItem = await context.Product_carts
//                        .FirstOrDefaultAsync(pc => pc.ProductId == item.ProductId && pc.UserId == item.UserId);

//                    if (existingItem == null)
//                    {
//                        context.Product_carts.Add(item);
//                    }
//                    else
//                    {
//                        existingItem.Quantity += item.Quantity;
//                    }
//                }

//                await context.SaveChangesAsync();
//                response.Data = cartItems;
//                response.Success = true;
//                response.Message = "Cart items stored successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Data = null;
//                response.Success = false;
//                response.Message = $"An error occurred: {ex.Message}";
//            }

//            return response;
//        }

//        // Thêm sản phẩm vào giỏ hàng
//        public async Task<ServiceResponse<bool>> AddProductToCart(Product_cart productCart)
//        {
//            var response = new ServiceResponse<bool>();
//            try
//            {
//                var existingItem = await context.Product_carts
//                    .FirstOrDefaultAsync(pc => pc.ProductId == productCart.ProductId && pc.UserId == productCart.UserId);

//                if (existingItem == null)
//                {
//                    context.Product_carts.Add(productCart);
//                }
//                else
//                {
//                    existingItem.Quantity += productCart.Quantity;
//                }

//                await context.SaveChangesAsync();
//                response.Data = true;
//                response.Success = true;
//                response.Message = "Product added to cart successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Data = false;
//                response.Success = false;
//                response.Message = $"An error occurred: {ex.Message}";
//            }

//            return response;
//        }

//        // Cập nhật số lượng sản phẩm
//        public async Task<ServiceResponse<bool>> UpdateProductQuantity(Product_cart productCart)
//        {
//            var response = new ServiceResponse<bool>();
//            try
//            {
//                var existingItem = await context.Product_carts
//                    .FirstOrDefaultAsync(pc => pc.ProductId == productCart.ProductId && pc.UserId == productCart.UserId);

//                if (existingItem != null)
//                {
//                    existingItem.Quantity = productCart.Quantity;
//                    await context.SaveChangesAsync();
//                    response.Data = true;
//                    response.Success = true;
//                    response.Message = "Product quantity updated successfully.";
//                }
//                else
//                {
//                    response.Data = false;
//                    response.Success = false;
//                    response.Message = "Product not found in cart.";
//                }
//            }
//            catch (Exception ex)
//            {
//                response.Data = false;
//                response.Success = false;
//                response.Message = $"An error occurred: {ex.Message}";
//            }

//            return response;
//        }

//    }
//}
using BanSach.Components.Data;
using BanSach.Components.IService;
using BanSach.Components.Model;
using Microsoft.EntityFrameworkCore;

namespace BanSach.Components.Services
{
    public class CartService : ICartService
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
