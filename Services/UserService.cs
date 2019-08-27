using System.Linq;
using System.Threading.Tasks;
using BookingClone.DB;
using BookingClone.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Services
{
    public class UserService: IUserService
    {
        private readonly BookingCloneContext Context;

        public UserService(BookingCloneContext context)
        {
            Context = context;
        }

        public async Task<AuthUser> getByEmailAsync(string email)
        {
            return await Context.Users
                .Where(u => u.Email == email)
                .Select(u => new AuthUser {
                    Id = u.Id,
                    Email = u.Email
                }).FirstAsync();
        }
    }
}