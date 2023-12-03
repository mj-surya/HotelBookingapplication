using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<UserController> _logger;

        public BookingController(IBookingService bookingService, ILogger<UserController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }
        /// <summary>
        /// Add the booking details
        /// </summary>
        /// <param name="bookingDTO">Details of booking to be added</param>
        /// <returns>The booking details</returns>
        [HttpPost("addBooking")]
        [Authorize(Roles = "User")]
        public ActionResult AddBooking(BookingDTO bookingDTO)
        {
            string message = string.Empty;  
            try
            {
                var booking = _bookingService.AddBookingDetails(bookingDTO);
                if (booking != null)
                {
                    _logger.LogInformation("Booked successfully");
                    return Ok(booking);
                }
                message = "Could not book";
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
           _logger.LogError("Could not book rooms");
            return BadRequest(message);
        }
        /// <summary>
        /// Retrieve the booking of hotel
        /// </summary>
        /// <param name="id">id of hotel to retrieve</param>
        /// <returns>All the booking details of a hotel</returns>
        [HttpGet("adminBooking")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAdminBooking(int id)
        {
            string message = string.Empty;
            try
            {
                var booking = _bookingService.GetBooking(id);
                    _logger.LogInformation("Admin booking details displayed");
                    return Ok(booking);
            }
            catch(NoBookingsAvailableException e)
            {
                message = e.Message;
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            _logger.LogError("Could not display admin bookings");
            return BadRequest(message);
        }
        /// <summary>
        /// Retrieve the user booking
        /// </summary>
        /// <param name="id">id of a user</param>
        /// <returns>bookiong dteails of a user</returns>
        [HttpGet("userBooking")]
        [Authorize(Roles = "User")]
        public ActionResult GetUserBooking(string id)
        {
            string message = string.Empty;
            try
            {
                var booking = _bookingService.GetUserBooking(id);
                _logger.LogInformation("User booking details displayed");
                 return Ok(booking);
            }
            catch(NoBookingsAvailableException ex)
            {
                message = ex.Message;
            }
            catch(Exception e)
            {
                message = e.Message;    
            }
            _logger.LogError("Could not display user bookings");
            return BadRequest(message);
        }
        /// <summary>
        /// Update the status of booking
        /// </summary>
        /// <param name="id">Booking id</param>
        /// <param name="status">Current status of booking</param>
        /// <returns>the updated status</returns>
        [HttpPost("Update")]
        public ActionResult UpdateBooking(int id,string status)
        {
            string message = string.Empty;
            try
            {
                var booking = _bookingService.UpdateBookingStatus(id, status);
                if (booking != null)
                {
                    _logger.LogInformation("Booking status updated");
                    return Ok(booking);
                }
                message = "couldn't update";
            }
            catch(Exception ex) {
                message = ex.Message;
            }
            _logger.LogError("Could not update booing status");
            return BadRequest(message);
        }
    }
}
