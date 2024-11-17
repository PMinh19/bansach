namespace BanSach.Components.Model
{
    public class Product_bill
    {
        public int UserId { get; set; }
        public int ProductBillId { get; set; }
        public int BillId { get; set; }
        public int Price { get; set; }
        public int FeaturePId { get; set; }
        public int Quantity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public List<Product_cart> ProductCarts { get; set; }
    }
}
