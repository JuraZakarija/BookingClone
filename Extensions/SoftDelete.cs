using System.Reflection;
using BookingClone.Models;

namespace BookingClone.Extensions
{
    public  static class SoftDelete
    {
        public static void SoftDeleteSetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            SetupQueryFilter<Agency>(modelBuilder);
            SetupQueryFilter<Booking>(modelBuilder);
            SetupQueryFilter<Guest>(modelBuilder);
            SetupQueryFilter<Hotel>(modelBuilder);
            SetupQueryFilter<Payment>(modelBuilder);
            SetupQueryFilter<Room>(modelBuilder);

        }

        private static void SetupQueryFilter<TEntity>(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
            where TEntity : BaseModel
        {
            if (typeof(BaseModel).GetTypeInfo().IsAssignableFrom(typeof(TEntity).Ge‌​tTypeInfo()))
            {
                modelBuilder.Entity<TEntity>().HasQueryFilter(temp => !temp.IsDeleted);
            }
        }
    }
}