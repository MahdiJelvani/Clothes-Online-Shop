using ShopStore.Models.Context;
using ShopStore.Service.Interface;

namespace ShopStore.Service
{
    public class RegisterService : IRegister
    {
        private readonly AppDbContext _context;

        public RegisterService(AppDbContext context)
        {
            _context = context;
        }

        public int addUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }
        public bool emailExist(string email)
        {
            return _context.Users.Any(u => u.UserEmail == email);
        }

        public bool userExist(string fName, string lName)
        {
            return _context.Users.Any(u => u.LName == lName && u.FName == fName);
        }
    }
}
