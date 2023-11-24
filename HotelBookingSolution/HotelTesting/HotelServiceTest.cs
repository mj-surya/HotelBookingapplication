using HotelBookingApplication.Contexts;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Repositories;
using HotelBookingApplication.Services;
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
        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<BookingContext>()
                                .UseInMemoryDatabase("dbTestCustomer")//a database that gets created temp for testing purpose
                                .Options;
            BookingContext context = new BookingContext(dbOptions);
            repository = new HotelRepository(context);
            roomRepository = new RoomRepository(context);
        }

        [Test]
        public void AddHotelTest()
        {
            //Arragne
            IHotelService hotelService = new HotelService(repository,roomRepository);
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

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(hotelDTO, result);
        }
        [Test]
        public void GetHotelTest()
        {
            // Arrange
            IHotelService hotelService = new HotelService(repository, roomRepository);
            string city = "Test";
            var hotelDTO = new HotelDTO
            {
                HotelName = "TestHotel2",
                City = "TestCity2",
                Address = "TestAddress2",
                UserId = "abc@gmail.com2",
                Phone = "1234567892",
                Description = "TestDescription2"

            };

            // Act
            hotelService.AddHotel(hotelDTO);
            var result = hotelService.GetHotels(city);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.Count);

        }
        [Test]
        public void UpdateTest()
        {
            //Arrange
            IHotelService hotelService = new HotelService(repository, roomRepository);
            int id = 2;
            var hotelDTO = new HotelDTO
            {
                HotelName = "TestHotel",
                City = "TestCity",
                Address = "TestAddress",
                UserId = "abc@gmail.com",
                Phone = "9988776655",
                Description = "TestDescription"
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
            IHotelService hotelService = new HotelService(repository, roomRepository);
            int id = 1;

            //Act
            var result = hotelService.RemoveHotel(id);
            Assert.IsTrue(result);        }
    }
}
