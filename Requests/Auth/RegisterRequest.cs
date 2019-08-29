using System.ComponentModel.DataAnnotations;

namespace BookingClone.Requests.Auth
{
    public class RegisterRequest: AppRequest
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
        
    }
}