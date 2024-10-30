namespace BanSach.Components.Model
{
    public class Product_bill
    {
        public int ProductBillId { get; set; }
        public int BillId { get; set; } 
        public int Price { get; set; }
        public int FeaturePId { get; set; }
        public int Quatity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
