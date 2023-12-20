using ShopStore.Models.Context;
using ShopStore.ViewModels;

namespace ShopStore.Service.Interface
{
    public interface ILogin
    {
        User userIsRegistered(LoginViewModel viewModel);
    }
}
