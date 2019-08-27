namespace BookingClone.Responses
{
    public class RegisterResponse
    {
        public string Token { get; set; }
        public AuthUserResponse User { get; set; }
    }
}