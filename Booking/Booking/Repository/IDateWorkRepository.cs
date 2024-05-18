using System.Linq.Expressions;
using Booking.Models;
using Booking.Models.Entities;

namespace Booking.Repository;

public interface IDateWorkRepository
{
    Task<DateWork?> Get(Expression<Func<DateWork, bool>> expression);

    Task<IEnumerable<AvailableRoomDto>> GetAll();
    
    //Task Update(DateWork dateWork);
}