namespace BanSach.Components.Model
{
    public class Product_cart
    {
        public int CartId { get; set; }
      
        public int ProductId { get; set; }
        public int Quatity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
