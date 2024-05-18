using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Booking.Models;
using Booking.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Controllers;

[Route("api/[controller]/[action]")]
public class FillDbController(BookingDbContext context) : ControllerBase
{
    [HttpPost]
    public async Task<Hotel> CreateHotel(string hotelName)
    {
        var hotel = new Hotel()
        {
            Name = hotelName
        };
        await context.Hotels.AddAsync(hotel);
        await context.SaveChangesAsync();
        return await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotelName);
    }

    [HttpPost]
    public async Task<Room> CreateRoom(Guid hotelId, int number)
    {
        var room = new Room()
        {
            HotelId = hotelId,
            Number = number
        };
        await context.Rooms.AddAsync(room);
        await context.SaveChangesAsync();
        return room;
    }

    [HttpPost]
    public async Task<DateWork> CreateDateWork(Guid roomId, DateTime dateTime, bool isAvailable)
    {
        var dt = dateTime.ToUniversalTime().Date;
        var dateWork = new DateWork()
        {
            RoomId = roomId,
            Date = dt,
            IsAvailable = isAvailable
        };
        await context.DateWorks.AddAsync(dateWork);
        await context.SaveChangesAsync();
        return dateWork;
    }
    
    [HttpPost]
    public async Task<User> CreateUser([FromBody] UserDto userDto)
    {
        var regex = new Regex("8\\d{10}");
        if (!regex.IsMatch(userDto.PhoneNumber))
            throw new ArgumentException("Требуется номер телефона в формате 80000000000");
        
        var user = new User()
        {
            Name = userDto.Name,
            LastName = userDto.LastName,
            PhoneNumber = userDto.PhoneNumber
        };
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }
}