using ShopStore.Models.Context;

namespace ShopStore.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string CardName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
