using Entity;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        static readonly string filePath = "..\\repository\\UsersData.txt";
        public User GetUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return user;
                }
            }
            return null;
        }
        public User AddUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return user;
        }

        public User GetUserByEmail(LoginUser loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == loginUser.Email && user.Password ==
                    loginUser.Password)
                        return user;
                }
            }
            return null;


        }
        public User UpdateUser(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                    {
                        textToReplace = currentUserInFile;
                        break;
                    }
                }
            }
            if (textToReplace != string.Empty)
            {
                userToUpdate.Id = id;
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }
            return userToUpdate;
        }

    }
}
