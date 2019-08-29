namespace BookingClone.Dto
{
    public class UserDto : BaseDto
    {  
        public string FirstName { get; set;}

        public string LastName { get; set;}

        public string FullName { get; set; }
        
        public string Birthdate { get; set; }
        
        public string Gender { get; set; }

        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }

        public int BookingCount { get; set; } = 0;
    }
}