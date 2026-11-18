using Entity;

namespace Service
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> Login(LoginUser loginUser);
        Task<User> UpdateUser(int id, User user);
        int ValidatePassword(string password);
    }
}