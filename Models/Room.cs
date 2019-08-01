using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BookingClone.Models
{
    public class Room : BaseModel
    {
        // Foreign keys
        public int HotelId { get; set; }

        [JsonIgnore]
        public Hotel Hotel { get; set; }


        [Column(TypeName = "decimal(6,2)")]
        [Range(0, 2000.00, ErrorMessage = "Veličina sobe mora bit između 0 i 2000 metara kvadratnih")]
        public decimal Size { get; set; }

        [Required (ErrorMessage = "Morate unijeti broj kreveta")]
        [Range(0, 20, ErrorMessage = "Soba može imati do 20 kreveta")]
        public int NumberOfBeds { get; set; }


        [MaxLength(100, ErrorMessage = "Ime tipa sobe mora biti kraće od 100 znakova")]
        public string Type { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}