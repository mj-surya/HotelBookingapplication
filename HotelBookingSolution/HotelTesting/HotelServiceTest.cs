using HotelBookingApplication.Contexts;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Repositories;
using HotelBookingApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTesting
{
    public class HotelServiceTest
    {
        IRepository<int, Hotel> repository;
        IRepository<int, Room> roomRepository;
        IRepository<int, Review> reviewRepository;
        IRepository<int, RoomAmenity> amenityRepository;
        IRepository<int, Booking> bookingRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<BookingContext>()
                                .UseInMemoryDatabase("dbTestCustomer")//a database that gets created temp for testing purpose
                                .Options;
            BookingContext context = new BookingContext(dbOptions);
            repository = new HotelRepository(context);
            roomRepository = new RoomRepository(context);
            amenityRepository = new RoomAmenityRepository(context);
            bookingRepository = new BookingRepository(context);
        }

        [Test]
        public void AddHotelTest()
        {
            //Arragne
            IHotelService hotelService = new HotelService(repository,roomRepository, reviewRepository);
            var hotelDTO = new HotelDTO
            {
                HotelName = "TestHotel",
                City = "TestCity",
                Address = "TestAddress",
                UserId = "abc1@gmail.com",
                Phone = "123456789",
                Description = "TestDescription",
                Image = new FormFile(Stream.Null, 0, 0, "TestImage", "TestData/Images/test.jpg")
            };


            // Act
            var result = hotelService.AddHotel(hotelDTO);   

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(hotelDTO, result);
        }
        [Test]
        public void GetHotelTest()
        {
            // Arrange
            IHotelService hotelService = new HotelService(repository, roomRepository, reviewRepository);
            IRoomService roomService = new RoomService(roomRepository, amenityRepository, bookingRepository);
            string city = "Test";
            var hotelDTO = new HotelDTO
            {
                HotelName = "TestHotel2",
                City = "TestCity2",
                Address = "TestAddress2",
                UserId = "abc@gmail.com2",
                Phone = "1234567892",
                Description = "TestDescription2",
                Image = new FormFile(Stream.Null, 0, 0, "TestImage", "TestData/Images/test.jpg")
            };
            var roomDTO = new RoomDTO
            {
                RoomType = "single",
                HotelId = 1,
                Price = 1000,
                Capacity = 2,
                Description = "description",
                TotalRooms = 2,
                Picture = new FormFile(Stream.Null, 0, 0, "TestImage", "TestData/Images/test.jpg"),
                roomAmenities = new List<string>
                {
                    "Wi-Fi",
                    "TV",
                    "Air Conditioning"
                }
            };

            //Action
           
            // Act
            hotelService.AddHotel(hotelDTO);
            var result = roomService.AddRoom(roomDTO);
            var result2 = hotelService.GetHotels(city);

            // Assert
            Assert.IsNotNull(result2);
            
        }
        [Test]
        public void UpdateTest()
        {
            //Arrange
            IHotelService hotelService = new HotelService(repository, roomRepository, reviewRepository);
            int id = 2;
            var hotelDTO = new UpdateHotelDTO
            {
                HotelName = "TestHotel",
                City = "TestCity",
                Address = "TestAddress",
                Phone = "9988776655",
                Description = "TestDescription",
               
            };

            //Act
            var result= hotelService.UpdateHotel(id, hotelDTO);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(hotelDTO, result);
        }
        [Test]
        public void DeleteTest()
        {
            //Arrange
            IHotelService hotelService = new HotelService(repository, roomRepository, reviewRepository);
            int id = 1;

            //Act
            var result = hotelService.RemoveHotel(id);

            //Assert
            Assert.IsTrue(result);        }
    }
}
