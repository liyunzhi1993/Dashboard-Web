using System.ComponentModel.DataAnnotations;

namespace MoFang.MobileSite.Core.Model.User
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberPassword { get; set; }
    }
}