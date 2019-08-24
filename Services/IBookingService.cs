using System;

namespace BookingClone.Services
{
    public interface IBookingService
    {
         bool IsAvailable(DateTime from, DateTime to, int roomId);
    }
}