namespace BookingClone.Dto
{
    public class HotelDto : BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string WebAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int RoomCount { get; set; } = 0;

    }
}