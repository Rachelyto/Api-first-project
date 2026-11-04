using Entity;

namespace Service
{
    public interface IUserService
    {
        User AddUser(User user);
        User GetUserById(int id);
        User Login(LoginUser loginUser);
        User UpdateUser(int id, User user);
        int ValidatePassword(string password);
    }
}