using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookingClone.Models
{
    public class AuthUser: IdentityUser<int>
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

        public string Role = "User";
        public ICollection<Booking> Bookings { get; set; }
    }
}