using Core.Security;
using ShopStore.Models.Context;
using ShopStore.Service.Interface;
using ShopStore.ViewModels;

namespace ShopStore.Service
{
    public class LoginService : ILogin
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }
        public User userIsRegistered(LoginViewModel viewModel)
        {
           viewModel.Password = PasswordEncript.EncriptPassword(viewModel.Password);
            return _context.Users
                 .FirstOrDefault(u => u.FName == viewModel.FName 
                 && u.LName == viewModel.LName && u.Password == viewModel.Password);
        }
    }
}
