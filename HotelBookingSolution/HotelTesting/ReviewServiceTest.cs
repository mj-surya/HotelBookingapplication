using HotelBookingApplication.Contexts;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Repositories;
using HotelBookingApplication.Services;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTesting
{
    public class ReviewServiceTest
    {
        IRepository<int, Review> repository;
        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<BookingContext>()
                                .UseInMemoryDatabase("dbTestCustomer")//a database that gets created temp for testing purpose
                                .Options;
            BookingContext context = new BookingContext(dbOptions);
            repository = new ReviewRepository(context);
        }
        [Test]
        public void AddReviewTest()
        {
            //Arragne
            IReviewService reviewService = new ReviewService(repository);
            var reviewDTO = new ReviewDTO
            {
                UserId = "test@gmail.com",
                HotelId= 1,
                Reviews = "Test",
                Rating = 5,
            };
            var reviewDTO2 = new ReviewDTO
            {
                UserId = "test2@gmail.com",
                HotelId = 1,
                Reviews = "Test2",
                Rating = 4,
            };

            //Act
            var result = reviewService.AddReview(reviewDTO);
            reviewService.AddReview(reviewDTO2);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test", result.Reviews);
        }
        [Test]
        public void GetReview()
        {
            //Arrange
            IReviewService reviewService = new ReviewService(repository);

            //Act
            var result = reviewService.GetReviews(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }
        [Test]
        public void UpdateReview()
        {
            //Arrange
            IReviewService reviewService = new ReviewService(repository);
            var reviewDTO = new ReviewDTO
            {
                UserId = "test@gmail.com",
                HotelId = 1,
                Reviews = "Test",
                Rating = 3,
            };

            //Act
            var result = reviewService.UpdateReview(1, reviewDTO);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Rating);

        }
        [Test]
        public void DeleteReview()
        {
            //Arrange
            IReviewService reviewService = new ReviewService(repository);
            int id = 2;

            //Act
            var result = reviewService.DeleteReview(id);

            //Assert
            Assert.IsTrue(result);
        }

    }
}
