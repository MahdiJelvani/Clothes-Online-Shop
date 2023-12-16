namespace ShopStore.Models.Context
{
    public class User
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public Cart Cart { get; set; }
    }
}
