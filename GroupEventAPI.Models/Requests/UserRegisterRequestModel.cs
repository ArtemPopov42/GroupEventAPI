using System.ComponentModel.DataAnnotations;

namespace GroupEventAPI.Models
{
    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage = "User name is required.")]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}