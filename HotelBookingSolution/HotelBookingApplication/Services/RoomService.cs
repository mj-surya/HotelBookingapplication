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
        /// <summary>
        /// Add the room based on the provided roomDTO
        /// </summary>
        /// <param name="roomDTO">roomDTO contain details of room</param>
        /// <returns>return the roomDTO if room added sucessfully; Otherwise return null</returns>
        public RoomDTO AddRoom(RoomDTO roomDTO)
        {
            //Create a new room object with details provided by the roomDTO
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

            //Add the room to the repository
            var result = _roomrepository.Add(room);

            //Retrieve the roomId of the added room
            int id = room.RoomId;

            //Iterator through each room amenities and add to the repository
            foreach (string a in roomDTO.roomAmenities)
            {
                RoomAmenity roomAmenity = new RoomAmenity()
                {
                    RoomId = id,
                    Amenities = a,
                };
                _roomAmenityRepository.Add(roomAmenity);
            }


            //Check if the room is added sucessfully return roomDTO; Otherwise return null
            if (result != null )
            {
                return roomDTO;
            }
            return null;
        }

        /// <summary>
        /// Retrieve the available rooms based on hotelId,checkIn and checkOut date
        /// </summary>
        /// <param name="hotelId">The unique id of a  hotel</param>
        /// <param name="checkIn">checkIn date</param>
        /// <param name="checkOut">checkOut date</param>
        /// <returns>retuen the available room</returns>
        /// <exception cref="NoRoomsAvailableException">throw no rooms are available to display</exception>
        public List<Room> GetRooms(int hotelId, string checkIn, string checkOut)
        {

            //Retrive the room based on the hotelId
            var room = _roomrepository.GetAll().Where(r => r.HotelId == hotelId).ToList();
            var availableRoom = CheckAvailableRooms(room , checkIn, checkOut);

            //Check if the room are available and return available room; Otherwise thrown no  rooms are available to display
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

        /// <summary>
        /// Delete the room based on the specified id
        /// </summary>
        /// <param name="id">The unique identifier of a room</param>
        /// <returns>Return true if room deleted sucessfully; Otherwise return false</returns>
        public bool RemoveRoom(int id)
        {
            //Delete the room with the provided id from  repository
            var roomcheck = _roomrepository.Delete(id);

            //Check if the room is deleted sucessfully then return true; Otherwise return false
            if (roomcheck != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update the room based on specified id and roomDTO
        /// </summary>
        /// <param name="id">The unique identifier of a room</param>
        /// <param name="roomDTO">roomDTO contains the updated details of room</param>
        /// <returns>Return the roomDTO if sucessfully added; Otherwise return null</returns>
        public RoomDTO UpdateRoom(int id, RoomDTO roomDTO)
        {
            //REtrieve the room based on the id from the repository
            var room = _roomrepository.GetById(id);

            //Check if the room is found
            if (room != null)
            {
                //Update the room based on the updated roomDTO
                room.Price = roomDTO.Price;
                room.Capacity = roomDTO.Capacity;
                room.TotalRooms = roomDTO.TotalRooms;
                room.Description = roomDTO.Description;
                room.RoomType = roomDTO.RoomType;
                var result = _roomrepository.Update(room);
                //Return roomDTO
                return roomDTO;
            }
            //Return null if room was not updated
            return null;
        }
    }
}
