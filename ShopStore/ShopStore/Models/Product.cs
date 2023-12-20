namespace ShopStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Rate { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int CategoryId { get; set;}
        public int ParentId { get; set; }
        public Size Size { get; set; }
        public Color Color{ get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public List<CartItem> CartItems { get; set; }
    }

    public enum Color
    {
        PINK,
        RED,
        GREEN,
        BLACK,
        BLUE,
        YELLOW
    }

    public enum Size
    {
        SMALL,
        MEDIUM,
        LARGE,
        XLARGE
    }
}
