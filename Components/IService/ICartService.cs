﻿using BanSach.Components.Model;
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
        Task<PaymentResult> ProcessPayment(int productBillId, string paymentMethod);
        Task<int> SaveShippingAddress(Address address);
        Task<ServiceResponse<int>> CreateBill(int addressId, int userId, decimal totalPrice, string note);
        Task<ServiceResponse<bool>> LinkBillToProductBill(int billId, List<Product_bill> productBills);
        Task SaveAddress(Address address);


    }
    public class PaymentResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
