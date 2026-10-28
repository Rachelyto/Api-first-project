using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //count isn't used: if you don't need it, delete it.
        //"Usersdata.txt" is written 5 times in this class: a static readonly string filePath field keeps it in one place
        private static int count = 0;
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "rachely", "toledano" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        //Why isn't it implemented? It should read the file and return the user with this id (or NotFound / NoContent)
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            int numberOfUsers = System.IO.File.ReadLines("Usersdata.txt").Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("Usersdata.txt", userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.Id },
            user);
            //return Ok(user);
        }
        // POST api/<UsersController>
        [HttpPost("login")]
        public ActionResult<UserLog> Post([FromBody] UserLog loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText("Usersdata.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == loginUser.LogInEmail && user.Password ==
                    loginUser.LogInPassword)
                        //RETURN USER TO CLIENT;
                        //Login doesn't create a new user, so return Ok(user) here (and the method returns ActionResult<User>, not ActionResult<UserLog>)
                        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);        
                }
            }
            return NoContent();


        }
        

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText("Usersdata.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if (textToReplace != string.Empty)
            {
                //fix: Keep the id, otherwise the updated user is saved without it
                userToUpdate.Id = id;
                string text = System.IO.File.ReadAllText("Usersdata.txt");
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText("Usersdata.txt", text);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    
}
