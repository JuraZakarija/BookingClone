using System;
using System.ComponentModel.DataAnnotations;
using BookingClone.Models;

namespace BookingClone.Dto
{
    public class BookingPostRequest
    {
        [Required]
        public int BookingId { get; set; }

        [Required]
        public int AgencyId { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoomId { get; set; }
    }
}