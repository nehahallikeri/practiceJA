using System.ComponentModel.DataAnnotations;

namespace TrainerCalenderApis.Data
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}
