using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;
using System.Runtime.Serialization;

namespace HotelBookingApplication.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<int, Room> _roomrepository;

        public RoomService(IRepository<int, Room> repository)
        {
            _roomrepository = repository;
        }

        public RoomDTO AddRoom(RoomDTO roomDTO)
        {
            Room room = new Room()
            {
                RoomType = roomDTO.RoomType,
                Price = roomDTO.Price,
                Capacity = roomDTO.Capacity,
                TotalRooms = roomDTO.TotalRooms,
                Description = roomDTO.Description,
            };
            var result = _roomrepository.Add(room);
            if (result != null)
                return roomDTO;
            return null;
        }

        public List<Room> GetRooms()
        {
            var room = _roomrepository.GetAll();
            if (room != null)
            {
                return room.ToList();
            }
            throw new NoRoomsAvailableException();
        }

        public bool RemoveRoom(int id)
        {
            var roomcheck = _roomrepository.GetAll().FirstOrDefault(r => r.RoomId == id);
            if (roomcheck != null)
            {
                var result = _roomrepository.Delete(id);
                return true;
            }
            return false;
        }

        public RoomDTO UpdateRoom(int id, RoomDTO roomDTO)
        {
            var room = _roomrepository.GetById(id);
            if (room != null)
            {
                room.Price = roomDTO.Price;
                room.Capacity = roomDTO.Capacity;
                room.TotalRooms = roomDTO.TotalRooms;
                room.Description = roomDTO.Description;
                room.RoomType = roomDTO.RoomType;
                var result = _roomrepository.Update(room);
                return roomDTO;
            }
            return null;
        }
    }
}
