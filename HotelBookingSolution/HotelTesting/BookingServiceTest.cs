using HotelBookingApplication.Contexts;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Repositories;
using HotelBookingApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTesting
{
    public class BookingServiceTest
    {
        IRepository<int, Booking> repository;
        IRepository<int, Room> roomRepository;
        IRepository<int, RoomAmenity> amenityRepository;
        IRepository<int, Hotel> hotelRepository;
        IRepository<string, User> userRepository;
        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<BookingContext>()
                                .UseInMemoryDatabase("dbTestCustomer")//a database that gets created temp for testing purpose
                                .Options;
            BookingContext context = new BookingContext(dbOptions);
            repository = new BookingRepository(context);
            hotelRepository = new HotelRepository(context);
            roomRepository = new RoomRepository(context);
            userRepository = new UserRepository(context);
           
        }

        [Test]
        
        public void AddBookingTest()
        {
            //Arrange
            IBookingService bookingService = new BookingService(repository, roomRepository, hotelRepository,userRepository);
            IHotelService hotelService = new HotelService(hotelRepository, roomRepository);
            IRoomService roomService = new RoomService(roomRepository, amenityRepository, repository);
            var appSettings = @"{""SecretKey"": ""Anything will work here this is just for testing""}";
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appSettings)));
            var tokenService = new TokenService(configurationBuilder.Build());
            IUserService userService = new UserService(userRepository, tokenService);

            userService.Register(new UserRegisterDTO
            {
                Email = "surya@gmail.com",
                Address = "xyz",
                ReTypePassword = "1234",
                Phone = "9988776655",
                Name = "surya",
                Role = "Admin",
                Password = "1234"
            });

            var hotelDTO = new HotelDTO
            {
                HotelName = "TestHotel",
                City = "TestCity",
                Address = "TestAddress",
                UserId = "abc@gmail.com",
                Phone = "123456789",
                Description = "TestDescription"

            };


            // Act
            var result = hotelService.AddHotel(hotelDTO);

            var roomDTO = new RoomDTO
            {
                RoomType = "single",
                HotelId = 1,
                Price = 1000,
                Capacity = 2,
                Description = "description",
                TotalRooms = 2,
                roomAmenities = { }
            };
            var result2 = roomService.AddRoom(roomDTO);


            var bookingDTO = new BookingDTO
            {
                UserId = "surya@gmail.com",
                CheckIn = "23-11-2023",
                CheckOut = "25-11-2023",
                RoomId = 1,
                TotalRoom = 1,
            };
            //Action
            var result1 = bookingService.AddBookingDetails(bookingDTO);

            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetBookingTest()
        {
            //Arrange
            IBookingService bookingService = new BookingService(repository, roomRepository, hotelRepository, userRepository);
            int hotelId = 1;

            //Action
            var result = bookingService.GetBooking(hotelId);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetUserBookingTest() 
        {
            //Arrange
            IBookingService bookingService = new BookingService(repository, roomRepository, hotelRepository, userRepository);
            string userId = "surya@gmail.com";

            //Action
            var result = bookingService.GetUserBooking(userId);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateBookingTest() {
            //Arrange
            IBookingService bookingService = new BookingService(repository, roomRepository, hotelRepository, userRepository);
            int id = 1;
            string status = "Cancelled";

            //Action
            var result = bookingService.UpdateBookingStatus(id, status);   
            
            //Assert
            Assert.AreEqual(result.Status,status);
        }
    }
}
