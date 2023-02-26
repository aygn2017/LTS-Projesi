using System.ComponentModel.DataAnnotations;

namespace LTS.WEBUI.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        //public string Token { get; set; }
    }
}
