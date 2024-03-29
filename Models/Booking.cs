using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BookingClone.Models
{
    public class Booking : BaseModel
    {
        // Foreign keys
        public int AgencyId { get; set; }
        
        [JsonIgnore]
        public Agency Agency { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public AuthUser User { get; set;}
        public int RoomId  { get; set; }

        [JsonIgnore]
        public Room Room { get; set; }


        [Required (ErrorMessage = "Morate unijeti datum prijave")]
        [DataType(DataType.Date, ErrorMessage = "Krivi format datuma")]
        public DateTime CheckIn { get; set; }


        [Required (ErrorMessage = "Morate unijeti datum odjave")]
        [DataType(DataType.Date, ErrorMessage = "Krivi format datuma")]
        public DateTime CheckOut { get; set; }
    }
}
