using HotelBookingApplication.Contexts;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Repositories;
using HotelBookingApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace HotelTesting
{
    public class UserServiceTest
    {
        IRepository<string, User> repository;
        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<BookingContext>()
                                .UseInMemoryDatabase("dbTestCustomer")//a database that gets created temp for testing purpose
                                .Options;
            BookingContext context = new BookingContext(dbOptions);
            repository = new UserRepository(context);
        }

        [Test]
        public void Test1()
        {
            //Arrange
            var appSettings = @"{""SecretKey"": ""Anything will work here this is just for testing""}";
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appSettings)));
            var tokenService = new TokenService(configurationBuilder.Build());
            IUserService userService = new UserService(repository, tokenService);
            userService.Register(new UserRegisterDTO
            {
                Email = "surya@gmail.com",
                Address = "xyz",
                ReTypePassword ="1234",
                Phone = "9988776655",
                Name = "surya",
                Role = "Admin",
                Password = "1234"
            });
            //Action
            var result = userService.Login(new UserDTO { Email = "surya@gmail.com", Password = "1234" });
            //Assert
            Assert.AreEqual("surya@gmail.com", result.Email);
        }
    }
}