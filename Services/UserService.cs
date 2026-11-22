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
            //What happens here when no user matches the email and password (user is null)?
            if (user.Password == loginUser.Password)
            {
                return user;
            }
            return null;
        }
        public async Task<User> UpdateUser(int id, User user)
        {
            //Score 2 passes this check (< 2), but the assignment asks weak passwords (score below 3) to return 400. What should the limit be?
            if (ValidatePassword(user.Password) < 2)
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
