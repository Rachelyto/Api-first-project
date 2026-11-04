using Entity;

namespace Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserByEmail(LoginUser loginUser);
        User GetUserById(int id);
        User UpdateUser(int id, User userToUpdate);
    }
}