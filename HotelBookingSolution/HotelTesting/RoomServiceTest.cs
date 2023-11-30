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
    public class RoomServiceTest
    {
        IRepository<int, Room> repository;
        IRepository<int, Hotel> hotelRepository;
        IRepository<int, RoomAmenity> amenityRepository;
        IRepository<int, Booking> bookingRepository;
        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<BookingContext>()
                                .UseInMemoryDatabase("dbTestCustomer")//a database that gets created temp for testing purpose
                                .Options;
            BookingContext context = new BookingContext(dbOptions);
            repository = new RoomRepository(context);
            hotelRepository = new HotelRepository(context);
            amenityRepository = new RoomAmenityRepository(context);
            bookingRepository = new BookingRepository(context);
        }

        [Test]
        public void AddRoomTest()
        {
            //Arrange
            IRoomService roomService = new RoomService(repository, amenityRepository, bookingRepository);

            var roomDTO = new RoomDTO
            {
                RoomType = "single",
                HotelId = 1,
                Price = 1000,

                Capacity = 2,
                Description = "description",
                TotalRooms = 2,
                roomAmenities = {}
            };

            //Action
            var result = roomService.AddRoom(roomDTO);

            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetRoomTest()
        {
            //Arrange
            IRoomService roomService = new RoomService(repository, amenityRepository, bookingRepository);
            int hotelId = 1;
            string checkIn = "23-11-2023";
            string checkOut = "25-11-2023";

            //Action
            var result = roomService.GetRooms(hotelId, checkIn, checkOut);
      
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.Count);
           
        }

        [Test]
        public void UpdateRoomsTest() {

            //Arrange
            IRoomService roomService = new RoomService(repository, amenityRepository, bookingRepository);
            var roomDTO = new RoomDTO
            {
                RoomType = "single",
                HotelId = 1,
                Price = 1000,

                Capacity = 4,
                Description = "description",
                TotalRooms = 2,
                roomAmenities = { }
            };

            //Action
             var result = roomService.UpdateRoom(1,roomDTO);
            
            //Assert
            Assert.IsNotNull(result);

            Assert.AreEqual(result.Capacity, roomDTO.Capacity);
        }

        [Test]
        public void DeleteRoomsTest()
        {
            //Arrange
            IRoomService roomService = new RoomService(repository, amenityRepository, bookingRepository);
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
            var result = roomService.AddRoom(roomDTO);

            //Action
            var result2 = roomService.RemoveRoom(2);

            //Assert
            Assert.IsTrue(result2);
        }
    }
}
