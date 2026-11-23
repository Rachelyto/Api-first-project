using Entity;
using Repository;
using Zxcvbn;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<User> GetUserById(int id)
        {
            return await repository.GetUserById(id);
        }

        public async Task<User> AddUser(User user)
        {
            if (ValidatePassword(user.Password) > 2)
                return await repository.AddUser(user);
            return null;
        }

        public async Task<User> Login(LoginUser loginUser)
        {
            User user =await repository.GetUserByEmailAndPassword(loginUser);
            if (user == null)
                return null;
            return user;      
        }
        public async Task<User> UpdateUser(int id, User user)
        {
            if (ValidatePassword(user.Password) < 3)
                return null;
            return await repository.UpdateUser(id, user);
        }

        public int ValidatePassword(string password)
        {
            int result = Core.EvaluatePassword(password).Score;
            return result;
        }
    }
}
