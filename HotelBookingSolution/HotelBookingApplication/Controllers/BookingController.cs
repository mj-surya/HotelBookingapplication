using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpPost("addBooking")]
        public ActionResult AddBooking(BookingDTO bookingDTO)
        {
            var booking = _bookingService.AddBookingDetails(bookingDTO);
            if (booking != null)
            {
                //_logger.LogInformation("Hotel Added");
                return Ok(booking);
            }
           // _logger.LogError("Could not add hotel");
            return BadRequest("Could not book");
        }

        [HttpGet("adminBooking")]
        public ActionResult GetAdminBooking(int id)
        {
            var booking = _bookingService.GetBooking(id);
            if(booking != null)
            {
                return Ok(booking);
            }
            return BadRequest("No bookings found");
        }

        [HttpGet("userBooking")]
        public ActionResult GetUserBooking(string id)
        {
            var booking = _bookingService.GetUserBooking(id);
            if (booking != null)
            {
                return Ok(booking);
            }
            return BadRequest("No bookings found");
        }

        [HttpPost("Update")]
        public ActionResult UpdateBooking(int id,string status)
        {
            var booking = _bookingService.UpdateBookingStatus(id,status);
            if (booking != null)
            {
                return Ok(booking);
            }
            return BadRequest("couldn't update");
        }
    }
}
