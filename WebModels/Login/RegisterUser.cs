using System.ComponentModel.DataAnnotations;

namespace WebModels
{
    public class RegisterUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PassWordHash { get; set; }
        
        [Required]
        public string Email { get; set; }
    }
}
