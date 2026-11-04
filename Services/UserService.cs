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
        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        public User AddUser(User user)
        {
            if (ValidatePassword(user.Password) > 2)
                return repository.AddUser(user);
            return null;
        }

        public User Login(LoginUser loginUser)
        {
            User user = repository.GetUserByEmail(loginUser);
            if (user.Password == loginUser.Password)
            {
                return user;
            }
            return null;
        }
        public User UpdateUser(int id, User user)
        {
            if (ValidatePassword(user.Password) < 2)
                return null;
            return repository.UpdateUser(id, user);
        }

        public int ValidatePassword(string password)
        {
            int result = Core.EvaluatePassword(password).Score;
            return result;
        }
    }
}
