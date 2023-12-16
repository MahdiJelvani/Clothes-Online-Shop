using ShopStore.Models.Context;

namespace ShopStore.Service.Interface
{
    public interface IRegister
    {
        bool userExist(string fName, string lName);
        bool emailExist(string email);
        int addUser(User user);
    }
}
