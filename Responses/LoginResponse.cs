using BookingClone.Models;

namespace BookingClone.Responses
{
    public class LoginResponse: AppResponse
    {
        public string Token { get; set; }

        public AuthUser User { get; set; }
    }
}