using System.Linq.Expressions;
using Booking.Models.Entities;

namespace Booking.Repository;

public interface IUserRepository
{
    Task<User?> Get(Expression<Func<User, bool>> expression);

}