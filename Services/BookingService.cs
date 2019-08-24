using System;
using System.Linq;
using BookingClone.DB;
using BookingClone.Shared;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingCloneContext context;
        
        public BookingService(
            BookingCloneContext context
        ) {
            this.context = context;
        }
        // public bool IsAvailablee(DateTime from, DateTime to, int roomId)
        // {
        //     var room = this.context.Rooms
        //         .Include(r => r.Bookings)
        //         .FirstOrDefault(r => r.Id == roomId);

        //         var bookings = room.Bookings;

        //         bool found = true;
        //         foreach(var booking in bookings)
        //         {
        //             DateTime checkIn = booking.CheckIn;
        //             DateTime checkOut = booking.CheckOut;
                    
        //             DateRange range = new DateRange(checkIn, checkOut);
        //             var result1 = range.Includes(from);
        //             var result2 = range.Includes(to);

        //             if(result1 || result2) {
                        
        //                 if(from < checkIn && to <= checkIn) {
        //                     found = true;
        //                     break;
        //                 }

        //                 found = false;
        //                 break;
        //             }
        //         }

        //     return found;
        // }

        public bool IsAvailable(DateTime checkIn, DateTime checkOut, int roomId)
        {
            var room = this.context.Rooms
                .Include(r => r.Bookings)
                .FirstOrDefault(r => r.Id == roomId);

                var bookings = room.Bookings;

                bool found = true;
                foreach(var booking in bookings)
                {
                    DateTime FirstDay = booking.CheckIn;
                    DateTime LastDay = booking.CheckOut;
                    
                    DateRange range = new DateRange(checkIn, checkOut);
                    var result1 = range.Includes(FirstDay);
                    var result2 = range.Includes(LastDay);

                    if(result1 || result2) {
                        
                        if(FirstDay < checkIn && LastDay <= checkIn) {
                            found = true;
                            break;
                        }

                        found = false;
                        break;
                    }
                }
            return found;
        }
    }
}
