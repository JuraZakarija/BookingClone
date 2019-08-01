using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingClone.Models
{
    public class Hotel : BaseModel
    {
        [Required (ErrorMessage = "Morate unijeti ime hotela")]
        [StringLength(100, ErrorMessage = "Ime hotela mora biti kraće od 100 znakova")]
        public string Name { get; set; }


        [Required (ErrorMessage = "Morate unijeti adresu hotela")]
        [StringLength(100, ErrorMessage = "Adresa hotela mora biti kraća od 100 znakova")]
        public string Address { get; set; }
        
        
        [Url (ErrorMessage = "Nije dobar format web adrese")]
        public string WebAddress { get; set; }
        
        
        [Phone (ErrorMessage = "Nije dobar format telefonskog broja")]
        public string PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}