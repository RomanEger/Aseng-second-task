using Booking.Repository;

namespace Booking.Extensions;

public static class ServiceExtension
{
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IDateWorkRepository, DateWorkRepository>()
            .AddScoped<IBookedRoomRepository, BookedRoomRepository>()
            .AddScoped<IRoomRepository, RoomRepository>();
    }
}