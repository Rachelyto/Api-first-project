using System.ComponentModel.DataAnnotations;

namespace webAPI
{
    public class UserLog
    {
        [EmailAddress]
        public string LogInEmail { get; set; }
        [Required]
        public string LogInPassword { get; set; }
        public int LogInId { get; set; }
    }
}
