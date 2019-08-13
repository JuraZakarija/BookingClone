using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BookingClone.Models
{
    public class Payment : BaseModel
    {

        Agency agency = new Agency();
        Booking booking = new Booking();
        Room room = new Room();

        public int AgencyId { get; set; }
        [JsonIgnore]
        public Agency Agency { get; set; }

        public int GuestId { get; set; }
        [JsonIgnore]
        public Guest Guest { get; set;}



        [Required (ErrorMessage = "Morate unijeti iznos cijene")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 99999999.99, ErrorMessage = "Cijena ne može biti negativna")]
        public decimal Price {
            get { return (room.PricePerNight * (booking.CheckOut - booking.CheckIn).Days) * (1 + agency.Commission/100); }
        }


        public ICollection<Booking> Bookings { get; set; }
    }
}