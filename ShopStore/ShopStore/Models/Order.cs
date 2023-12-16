using ShopStore.Models.Context;

namespace ShopStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
