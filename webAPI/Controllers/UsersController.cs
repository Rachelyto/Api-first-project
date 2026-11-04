using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "rachely", "toledano" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = userService.GetUserById(id);
            if (user == null) return NoContent();
            return Ok(user);
        }
        [HttpPost("checkPassword")]
        public int passwordCheck([FromBody] string password)
        {
            return userService.ValidatePassword(password);
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            User added = userService.AddUser(user);
            if (added == null) return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = added.Id },
            added);
        }
        // POST api/<UsersController>
        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] LoginUser loginUser)
        {
            User login = userService.Login(loginUser);
            if(login == null) return NoContent();              
            return Ok(login);
        }
        

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User userToUpdate)
        {
            User update=userService.UpdateUser(id, userToUpdate);
            if (update == null) return BadRequest();
            return Ok(update);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    
}
