using System.ComponentModel.DataAnnotations;

namespace webAPI
{
    public class User
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int Id { get; set; }



    }
}
