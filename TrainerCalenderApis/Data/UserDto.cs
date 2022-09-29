using System.ComponentModel.DataAnnotations;

namespace TrainerCalenderApis.Data
{
    public class UserDto
    {
        [Required]
        public string email { get; set; }
        public string password { get; set; }
    }
}
