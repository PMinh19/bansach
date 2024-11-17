//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
//using BanSach.Components.IService;
//using BanSach.Components.Model;

//namespace BanSach.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CartController : ControllerBase
    
//        private readonly ICartService _cartService;

//        public CartController(ICartService cartService)
//        {
//            _cartService = cartService;
//        }

//        // Lấy danh sách sản phẩm trong giỏ hàng từ cơ sở dữ liệu
//        [HttpPost("products")]
//        public async Task<ActionResult<ServiceResponse<List<Product_cart>>>> GetCartProducts([FromBody] List<Product_cart> cartItems)
//        {
//            var result = await _cartService.GetCartProducts(cartItems);
//            return Ok(result);
//        }

//        // Lưu danh sách sản phẩm vào giỏ hàng
//        [HttpPost("store")]
//        public async Task<ActionResult<ServiceResponse<List<Product_cart>>>> StoreCartItems([FromBody] List<Product_cart> cartItems)
//        {
//            var result = await _cartService.StoreCartItems(cartItems);
//            return Ok(result);
//        }

//        // Thêm sản phẩm vào giỏ hàng
//        [HttpPost("add")]
//        public async Task<ActionResult<ServiceResponse<bool>>> AddProductToCart([FromBody] Product_cart cartItem)
//        {
//            var result = await _cartService.AddProductToCart(cartItem);
//            return Ok(result);
//        }

//        // Cập nhật số lượng sản phẩm trong giỏ hàng
//        [HttpPut("update-quantity")]
//        public async Task<ActionResult<ServiceResponse<bool>>> UpdateProductQuantity([FromBody] Product_cart cartItem)
//        {
//            var result = await _cartService.UpdateProductQuantity(cartItem);
//            return Ok(result);
//        }

//        // Xóa sản phẩm khỏi giỏ hàng
//        [HttpDelete("{productId}/{userId}")]
//        public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCart(int productId, int userId)
//        {
//            var result = await _cartService.RemoveItemFromCart(productId, userId);
//            return Ok(result);
//        }

//        // Lấy tổng số lượng sản phẩm trong giỏ hàng
//        [HttpGet("count/{userId}")]
//        public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount(int userId)
//        {
//            var result = await _cartService.GetCartItemsCount(userId);
//            return Ok(result);
//        }

//        // Lấy danh sách sản phẩm trong giỏ hàng từ database cho người dùng hiện tại
//        [HttpGet("user/{userId}")]
//        public async Task<ActionResult<ServiceResponse<List<Product_cart>>>> GetDbCartProducts(int userId)
//        {
//            var result = await _cartService.GetDbCartProducts(userId);
//            return Ok(result);
//        }
//    }
//}
