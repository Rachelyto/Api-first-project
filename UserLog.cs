using System.ComponentModel.DataAnnotations;

namespace webAPI
{
    //A clearer name is LoginUser, and Email and Password are enough as property names.
    //LogInId isn't used for login: if you don't need it, delete it
    public class UserLog
    {
        [EmailAddress]
        public string LogInEmail { get; set; }
        [Required]
        public string LogInPassword { get; set; }
        public int LogInId { get; set; }
    }
}
