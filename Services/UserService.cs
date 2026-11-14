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
            //What happens if no user has this email? user is null here, so user.Password fails: how could you check for null first?
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
