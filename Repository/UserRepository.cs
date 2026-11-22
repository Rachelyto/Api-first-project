using Entity;
using Microsoft.EntityFrameworkCore;
//This using isn't used in this file: you can remove it
using System.Text.Json;

namespace Repository
{
    
    public class UserRepository : IUserRepository
    {
        //This line doesn't compile: the type _216775882_MyStoreDBContext can't be found here
        _216775882_MyStoreDBContext dbContext;
        public UserRepository(_216775882_MyStoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await dbContext.Users.ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await dbContext.Users.FindAsync(id);
        }
        public async Task<User> AddUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmailAndPassword(LoginUser loginUser)
        {
            return await dbContext.Users.Where(user=>user.Email==loginUser.Email && user.Password==loginUser.Password).FirstOrDefaultAsync();
            
        }
        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            userToUpdate.Id = id;
            dbContext.Users.Update(userToUpdate);
            await dbContext.SaveChangesAsync();
            return userToUpdate;
        }

    }
}
