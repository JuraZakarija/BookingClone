using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingClone.Models
{
    public class Agency : BaseModel
    {
        [Required (ErrorMessage = "Morate unijeti ime turističke agencije")]
        [MaxLength(100, ErrorMessage = "Ime agencije mora biti kraće od 100 znakova")]
        public string Name { get; set; }


        [Required (ErrorMessage = "Morate unijeti iznos provizije")]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 999.99, ErrorMessage = "Provizija mora biti između 0 i 99 %")]
        public decimal? Commission { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}