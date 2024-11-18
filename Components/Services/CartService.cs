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

        public CartService(AppDbContext _db, HttpClient http)
        {
            db = _db;
            this.http = http;
        }
        public async Task<List<Product_cart>> GetAllPCart()
        {
            return await db.Product_carts.Include(p => p.Product).ToListAsync();
        }
        public async Task<Product_cart> CreatePCart(Product_cart productCart)
        {
            // Kiểm tra xem sự kết hợp UserId và ProductId đã tồn tại trong Product_carts chưa
            var existingProductCart = await db.Product_carts
                .FirstOrDefaultAsync(pc => pc.UserId == productCart.UserId && pc.ProductId == productCart.ProductId);

            if (existingProductCart != null)
            {
                // Nếu đã tồn tại, chỉ cần cập nhật số lượng sản phẩm
                existingProductCart.Quantity += productCart.Quantity;
                existingProductCart.Updated = DateTime.Now;  // Cập nhật thời gian sửa đổi
            }
            else
            {
                // Nếu không tồn tại, thêm mới sản phẩm vào giỏ hàng
                productCart.Created = DateTime.Now;
                productCart.Updated = DateTime.Now;
                db.Product_carts.Add(productCart);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            await db.SaveChangesAsync();

            // Trả về đối tượng Product_cart vừa được thêm hoặc cập nhật
            return productCart;
        }



        public async Task DeletePCart(Product_cart Product_cart)
        {
            db.Product_carts.Remove(Product_cart);
            await db.SaveChangesAsync();
        }

        public async Task<Product_bill> PlaceProductBill(Product_bill productBill)
        {
            // Gán giá trị mặc định cho PaymentStatus nếu chưa có giá trị
            if (string.IsNullOrEmpty(productBill.PaymentStatus))
            {
                productBill.PaymentStatus = "Chưa thanh toán";  // Hoặc giá trị mặc định nào đó mà bạn muốn
            }

            Console.WriteLine($"ProductBill - FeaturePId: {productBill.FeaturePId}, Price: {productBill.Price}, Quantity: {productBill.Quantity}");
            db.Product_bills.Add(productBill);  // Thêm hóa đơn vào cơ sở dữ liệu
            await db.SaveChangesAsync();

            // Xử lý giỏ hàng của người dùng (cập nhật trạng thái hoặc xóa giỏ hàng nếu cần)
            var cartItems = await db.Product_carts.Where(p => p.UserId == productBill.UserId).ToListAsync();
            foreach (var item in cartItems)
            {
                Console.WriteLine($"CartItem - ProductId: {item.ProductId}, Quantity: {item.Quantity}");
                item.IsCheckedOut = true;
            }

            await db.SaveChangesAsync();
            Console.WriteLine("Đã lưu hóa đơn thành công!");
            return productBill;
        }



        public async Task<Product_bill> GetProductBillById(int productBillId)
        {
            return await db.Product_bills
                    .Include(pb => pb.ProductCarts)  // Kết nối với các sản phẩm trong hóa đơn
                    .FirstOrDefaultAsync(pb => pb.ProductBillId == productBillId);
        }

        public async Task<PaymentResult> ProcessPayment(int productBillId, string paymentMethod)
        {
            try
            {
                var productBill = await db.Product_bills.FirstOrDefaultAsync(pb => pb.ProductBillId == productBillId);

                if (productBill == null)
                {
                    return new PaymentResult { IsSuccess = false, Message = "Hóa đơn không tồn tại." };
                }

                if (paymentMethod == "Tiền mặt")
                {
                    productBill.PaymentStatus = "Đã đặt đơn và xác nhận thanh toán bằng tiền mặt khi nhận hàng.";
                }
                else if (paymentMethod == "Ví điện tử")
                {
                    productBill.PaymentStatus = "Đã đặt đơn và chờ thanh toán qua ví điện tử.";
                }
                else
                {
                    return new PaymentResult { IsSuccess = false, Message = "Phương thức thanh toán không hợp lệ." };
                }


                await db.SaveChangesAsync();
                return new PaymentResult { IsSuccess = true, Message = "Thanh toán thành công." };
            }
            catch (Exception ex)
            {
                return new PaymentResult { IsSuccess = false, Message = $"Lỗi trong quá trình thanh toán: {ex.Message}" };
            }
        }

    }
}

