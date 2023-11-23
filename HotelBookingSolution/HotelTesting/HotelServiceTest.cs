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

            //repository.Setup(repo => repo.Add(It.IsAny<Hotel>())).Returns(new Hotel());

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
                HotelName = "TestHotel",
                City = "TestCity",
                Address = "TestAddress",
                UserId = "abc@gmail.com",
                Phone = "123456789",
                Description = "TestDescription"
            };

            //repository.Setup(repo => repo.Add(It.IsAny<Hotel>())).Returns(new Hotel());

            // Act
            var result = hotelService.AddHotel(hotelDTO);
            //var result2 = hotelService.GetHotels(city);

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsNotEmpty(result2); // Ensure that the result is not an empty list

            // You might want to add more assertions based on the expected behavior of your GetHotels method
            //Assert.AreEqual(2, result.Count); // Assuming you added two hotels in this test
            //Assert.IsTrue(result.All(hotel => hotel.City == city));

        }
    }

}
