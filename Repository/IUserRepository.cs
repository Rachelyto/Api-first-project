using Entity;

namespace Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> AddUser(User user);
        Task<User> GetUserByEmailAndPassword(LoginUser loginUser);
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}