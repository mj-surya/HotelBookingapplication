using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Repositories;
using System.Runtime.Serialization;

namespace HotelBookingApplication.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<int, Room> _roomrepository;
        private readonly IRepository<int, RoomAmenity> _roomAmenityRepository;
        private readonly IRepository<int, Booking> _bookingRepository;

        public RoomService(IRepository<int, Room> repository, IRepository<int, RoomAmenity> roomAmenityRepository, IRepository<int, Booking> bookingRepository)
        {
            _roomrepository = repository;
            _roomAmenityRepository = roomAmenityRepository;
            _bookingRepository = bookingRepository;
        }

        public RoomDTO AddRoom(RoomDTO roomDTO)
        {
            Room room = new Room()
            {
                RoomType = roomDTO.RoomType,
                Price = roomDTO.Price,
                HotelId=roomDTO.HotelId,
                Capacity = roomDTO.Capacity,
                TotalRooms = roomDTO.TotalRooms,
                Picture = roomDTO.Picture,
                Description = roomDTO.Description,
            };
            var result = _roomrepository.Add(room);
            int id = room.RoomId;
            foreach (string a in roomDTO.roomAmenities)
            {
                RoomAmenity roomAmenity = new RoomAmenity()
                {
                    RoomId = id,
                    Amenities = a,
                };
                _roomAmenityRepository.Add(roomAmenity);
            }
            if (result != null )
            {
                
                return roomDTO;
            }
            return null;
        }

        public List<Room> GetRooms(int hotelId, string checkIn, string checkOut)
        {
            var room = _roomrepository.GetAll().Where(r => r.HotelId == hotelId).ToList();
            var availableRoom = CheckAvailableRooms(room , checkIn, checkOut);
            if (room.Count != 0)
            {
                return availableRoom;
            }
            throw new NoRoomsAvailableException();
        }

        private List<Room> CheckAvailableRooms(List<Room> room, string checkIn, string checkOut)
        {
            List<Room> roomList = new List<Room>();
            foreach (var a in room)
            {
                var booking = (from Booking in _bookingRepository
            .GetAll()
            .Where(booking =>
                booking.RoomId == a.RoomId &&
                (DateTime.Parse(checkIn).Date >= DateTime.Parse(booking.CheckIn).Date &&
                 DateTime.Parse(checkIn).Date <= DateTime.Parse(booking.CheckOut).Date ||
                 DateTime.Parse(checkOut).Date <= DateTime.Parse(booking.CheckOut).Date &&
                 DateTime.Parse(checkOut).Date >= DateTime.Parse(booking.CheckIn).Date))
                 select Booking
            )
            .ToList();
                int count = 0;
                foreach (var b in booking)
                {
                    count += b.TotalRoom;
                }
                a.TotalRooms -= count;
                roomList.Add(a);
            }
            return roomList;
        }
        public bool RemoveRoom(int id)
        {

            var roomcheck = _roomrepository.Delete(id);
            if (roomcheck != null)
            {
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
