namespace ShopStore.Generic
{
    public class FixedEmail
    {
        public static string FixedText(string email) 
        { 
            return email.Trim().ToLower();
        }
    }
}
