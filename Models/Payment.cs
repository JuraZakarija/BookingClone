using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingClone.Models
{
    public class Payment : BaseModel
    {

        Room room = new Room();
        Booking booking = new Booking();
        
        [Required (ErrorMessage = "Morate unijeti iznos osnovice")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 99999999.99, ErrorMessage = "Osnovica ne može biti negativna")]
        public decimal Price { 
            get{ return room.PricePerNight * (booking.CheckOut - booking.CheckIn).Days; }
        }



        [Required (ErrorMessage = "Morate unijeti iznos marže")]
        [Column(TypeName = "decimal(4,2)")]
        [Range(0, 99.99, ErrorMessage = "Porez mora biti između 0 i 99 %")]
        public decimal Margin { get; set; }


        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 99999999.99, ErrorMessage = "Ukupna cijena ne može biti negativna")]
        public decimal Total {
            get { return Price * (1 + Margin / 100); }
        }

        public ICollection<Booking> Bookings { get; set; }
    }
}