using System;
using System.ComponentModel.DataAnnotations;

namespace BookingClone.Dto
{
    public class AvailabilityRequest
    {
        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime CheckIn {get; set;}

        [Required]
        public DateTime CheckOut {get; set;}
    }
}