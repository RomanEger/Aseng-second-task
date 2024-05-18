using System.Linq.Expressions;
using Booking.Models;
using Booking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository;

public class UserRepository(BookingDbContext context) : IUserRepository
{
    public async Task<User?> Get(Expression<Func<User, bool>> expression)
    {
        return await context.Set<User>().FirstOrDefaultAsync(expression);
    }

}