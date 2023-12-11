using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<int, Review> _reviewRepository;
        private readonly IRepository<int, Hotel> _hotelRepository;

        private readonly IRepository<int, Room> _roomRepository;

        public HotelService(IRepository<int, Hotel> repository, IRepository<int, Room> roomRepository, IRepository<int,Review> reviewRepository)
        {
            _reviewRepository=reviewRepository;
            _hotelRepository = repository;

            _roomRepository = roomRepository;
        }
        /// <summary>
        /// Add the hotel details based on the provided hotelDTO
        /// </summary>
        /// <param name="hotelDTO">hotelDTO contains the details of hotel</param>
        /// <returns>Returns the HotelDTO if hotel was added successfully; Otherwise return null</returns>
        public HotelDTO AddHotel(HotelDTO hotelDTO)
        {
            Hotel check;   
            try
            {
                check = _hotelRepository.GetAll().FirstOrDefault(u => u.UserId == hotelDTO.UserId);
            }
            catch(Exception)
            {
                check = null;
            }
           
            if (check == null)
            {
                //Create a new hotel object based on the details of hotelDTO
                Hotel hotel = new Hotel()
                {
                    HotelName = hotelDTO.HotelName,
                    City = hotelDTO.City,
                    Address = hotelDTO.Address,
                    UserId = hotelDTO.UserId,
                    Phone = hotelDTO.Phone,
                    Description = hotelDTO.Description,
                    Image = "http://localhost:5272/Images/" + hotelDTO.Image.FileName
                };
                //Add the hotel to the repository

                var result = _hotelRepository.Add(hotel);
                if (result != null)
                {
                    //Check if the hotel added sucessfully and returns the hotelDTO
                    return hotelDTO;
                }
                //Returns null if the hotel was not added
                return null;
            }
            else
            {
                throw new AlreadyAvailableException();
            }
           

        }
        /// <summary>
        /// Retrieve the list of hotel object based on the city
        /// </summary>
        /// <param name="city">City to search for the hotel address </param>
        /// <returns>Return the list of hotel based on city</returns>
        /// <exception cref="NoHotelsAvailableException">Thrown when the no hotels are available for the specified city</exception>

        public List<HotelDisplayDTO> GetHotels(string city)
        {
            try
            {
                //Retrieve the hotel based on the address containing containing the city from the repository
                var hotels = _hotelRepository.GetAll().Where(c => c.Address.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList();
                List<HotelDisplayDTO> dto = new List<HotelDisplayDTO>();
                //Iterating through each hotel to calculate the starting price based on the minimum room price
                foreach (var a in hotels)
                {
                    int id = a.HotelId;
                    try
                    {
                        if (_roomRepository.GetAll().Where(r => r.HotelId == id) != null)
                        {
                            //Calculate the minimum price among all room in the hotel
                            float price = (from Room in _roomRepository.GetAll()
                                           where Room.HotelId == id
                                           select (Room.Price))
                            .Min();
                            a.StartingPrice = price;
                        }
                        float avg = 0;
                        try
                        {
                            avg = _reviewRepository.GetAll().Where(r => r.HotelId == id).Select(r => r.Rating).Average();
                        }catch(Exception)
                        {
                            avg = 0;
                        }
                        
                        HotelDisplayDTO avgRating = new HotelDisplayDTO()
                        {
                            HotelId = a.HotelId,
                            HotelName = a.HotelName,
                            City = a.City,
                            Address = a.Address,
                            UserId = a.UserId,
                            Phone = a.Phone,
                            Description = a.Description,
                            Image = a.Image,
                            StartingPrice = a.StartingPrice,
                            AvgRating = avg
                        };
                        dto.Add(avgRating);

                    }catch (Exception )
                    {
                        a.StartingPrice = 0;
                    }
                    //Check if the hotel has room
                    
                }

                // Check if the hotel is found with the specified city returns the hotel; Otherwise throws a new NoHotelsAvailableException
                if (hotels != null)
                {
                    return dto;
                }
            }
            catch (Exception )
            // Check if the hotel is found with the specified city returns the hotel; Otherwise throws a new NoHotelsAvailableException
            {
                throw new NoHotelsAvailableException();
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
            if (result != null)
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
        public UpdateHotelDTO UpdateHotel(int id, UpdateHotelDTO hotelDTO)
        {
            //Retrieve the specified id from the repository
            var hotel = _hotelRepository.GetById(id);

            //Check if the hotel is found
            if (hotel != null)
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
        /// <summary>
        /// Gets the hotel with userId
        /// </summary>
        /// <param name="id">user Id </param>
        /// <returns>returns the hotel data associated with the userID or returns null</returns>
        public Hotel GetByUserId(string id)
        {
            var hotel = _hotelRepository.GetAll().FirstOrDefault(u => u.UserId == id);
            if (hotel != null)
                return hotel;
            return null;

        }
    }
}