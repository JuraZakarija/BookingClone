using System.Threading.Tasks;
using BookingClone.Models;

namespace BookingClone.Services
{
    public interface IUserService
    {
        Task<AuthUser> getByEmailAsync(string email);
    }
}