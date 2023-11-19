using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<int, Hotel> _hotelRepository;
        private readonly IRepository<int, Review> _reviewRepository;
        private readonly IRepository<int, Room> _roomRepository;

        public HotelService(IRepository<int, Hotel> repository, IRepository<int, Review> reviewRepository, IRepository<int, Room> roomRepository)
        {
            _hotelRepository = repository;
            _reviewRepository = reviewRepository;
            _roomRepository = roomRepository;
        }
        /// <summary>
        /// Add the hotel details based on the provided hotelDTO
        /// </summary>
        /// <param name="hotelDTO">hotelDTO contains the details of hotel</param>
        /// <returns>Returns the HotelDTO if hotel was added successfully; Otherwise return null</returns>
        public HotelDTO AddHotel(HotelDTO hotelDTO)
        {
            //Create a new hotel object based on the details of hotelDTO
            Hotel hotel = new Hotel()
            {
                HotelName = hotelDTO.HotelName,
                City = hotelDTO.City,
                Address = hotelDTO.Address,
                UserId= hotelDTO.UserId,
                Phone = hotelDTO.Phone,
                Description = hotelDTO.Description,
            };
            //Add the hotel to the repository
            var result = _hotelRepository.Add(hotel);
             //Check if the hotel added sucessfully and returns the hotelDTO
            if(result != null)
            {
                return hotelDTO;
            }
            //Returns null if the hotel was not added
            return null;
        }
        /// <summary>
        /// Retrieve the list of hotel object based on the city
        /// </summary>
        /// <param name="city">City to search for the hotel address </param>
        /// <returns>Return the list of hotel based on city</returns>
        /// <exception cref="NoHotelsAvailableException">Thrown when the no hotels are available for the specified city</exception>
        public List<Hotel> GetHotels(string city)
        {
            //Retrieve the hotel based on the address containing containing the city from the repository
            var hotels = _hotelRepository.GetAll().Where(c => c.Address.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList(); 

            //Iterating through each hotel to calculate the starting price based on the minimum room price
            foreach (var a in hotels)
            {
                int id = a.HotelId;

                //Check if the hotel has room
                if(_roomRepository.GetAll().Where(r => r.HotelId == id).ToList().Count != 0)
                {

                    //Calculate the minimum price among all room in the hotel
                    float price = (from Room in _roomRepository.GetAll()
                                   where Room.HotelId == id
                                   select (Room.Price))
                    .Min();
                    a.StartingPrice = price;
                }
                
            }

            // Check if the hotel is found with the specified city returns the hotel; Otherwise throws a new NoHotelsAvailableException
            if (hotels != null)
            {
                return hotels;
            }
            throw new NoHotelsAvailableException();
        }

        /// <summary>
        /// Delete the hotel based on the unique identifier of a hotel
        /// </summary>
        /// <param name="id">the unique identifier of a hotel</param>
        /// <returns>Returns true if hotel was removed successfully; Otherwise returns false</returns>
        public bool RemoveHotel(int id)
        {
            //Delete the hotel from the repository based on id
            var result = _hotelRepository.Delete(id);

            //Check if the hotel is deleted successfully and returns true; Otherwise returns false
            if(result!= null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the hotel based on unique hotel id and hotelDTO
        /// </summary>
        /// <param name="id">The unique hotel Id</param>
        /// <param name="hotelDTO">hotelDTO contains the updated details of hotel</param>
        /// <returns>Return hotelDTO when the update was success; Otherwise return null</returns>
        public HotelDTO UpdateHotel(int id,HotelDTO hotelDTO)
        { 
            //Retrieve the specified id from the repository
            var hotel = _hotelRepository.GetById(id);

            //Check if the hotel is found
            if(hotel != null)
            {
                //Update the hotel details provided by the hotelDTO
                hotel.Phone = hotelDTO.Phone;
                hotel.Address = hotelDTO.Address;
                hotel.HotelName = hotelDTO.HotelName;
                hotel.City = hotelDTO.City;
                hotel.Description = hotelDTO.Description;

                //Update the hotel in the repository
                var result = _hotelRepository.Update(hotel);

                //Returns the updated hotelDTO
                return hotelDTO;
            }
            //Return null if the hotel was not found
            return null;
        }
    }
}
