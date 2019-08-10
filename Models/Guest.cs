using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BookingClone.Models
{
    public class Guest : BaseModel
    {         
        [Required (ErrorMessage = "Morate unijeti ime gosta")]
        [MaxLength(100, ErrorMessage = "Ime gosta mora biti kraća od 100 znakova")]
        public string FirstName { get; set; }
        

        [Required (ErrorMessage = "Morate unijeti prezime gosta")]
        [MaxLength(100, ErrorMessage = "Preazme gosta mora biti kraća od 100 znakova")]
        public string LastName { get; set; }


        [DataType(DataType.Date, ErrorMessage = "Unjeli ste krivi format datuma")]
        public DateTime? Birthdate { get; set; }
        

        [RegularExpression(@"M|F", ErrorMessage =  "Spol gosta se označava s jednim znakom: M ili F")]       
        public string Gender { get; set; }


        [Phone (ErrorMessage = "Krivi format telefonskog broja")]// max length
        public string PhoneNumber { get; set; }
        

        [EmailAddress (ErrorMessage = "Krivi format email adrese")]
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}