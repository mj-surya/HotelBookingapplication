using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetRooms();
        RoomDTO AddRoom(RoomDTO room);
        RoomDTO UpdateRoom(int id, RoomDTO room);
        bool RemoveRoom(int id);
    }
}
