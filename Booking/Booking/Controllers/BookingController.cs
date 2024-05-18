using Booking.Models;
using Booking.Models.Entities;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers;

[Route("api/[controller]")]
public class BookingController(BookingService bookingService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Booking([FromBody] BookingRequestDto bookingRequestDto)
    {
        var user = await bookingService.GetUserAsync(x => x.LastName == bookingRequestDto.LastName && x.PhoneNumber == bookingRequestDto.PhoneNumber);
        
        if (user is null)
            return BadRequest("Отклонено.\nПользователь не найден");

        var room = await bookingService.GetRoomAsync(bookingRequestDto.HotelName, bookingRequestDto.RoomNumber);
        
        if(room is null)
            return BadRequest("Отклонено.\nНомер не найден");
        
        var dateWork = await bookingService.GetDateWorkAsync(x => x.RoomId == room.Id && x.IsAvailable && x.Date.Date == bookingRequestDto.Date.Date);

        if (dateWork is null)
            return BadRequest("Отклонено");

        var bookedRoom = new BookedRoom()
        {
            UserId = user.Id,
            BookedDate = bookingRequestDto.Date.Date,
            RoomId = room.Id
        };

        await bookingService.BookRoomAsync(bookedRoom);
        var changes = await bookingService.SaveChangesAsync();
        
        return Ok("Забронировано");
    }

    [HttpGet]
    public async Task<IActionResult> Rooms()
    {
        var data = await bookingService.GetAvailableRoomsAsync();
        return Ok(data);
    }
}