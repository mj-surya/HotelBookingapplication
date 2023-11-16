using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger _logger;

        public HotelController(IHotelService hotelService, ILogger<HotelController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }
        [HttpPost("AddHotel")]
        [Authorize(Roles ="Admin")]
        public ActionResult AddHotel(HotelDTO hotelDTO)
        {
            var hotel = _hotelService.AddHotel(hotelDTO);
            if(hotel!=null)
            {
                return Ok(hotel);
                _logger.LogInformation("Hotel Added");
            }
            return BadRequest("Could not add hotel");
            _logger.LogError("Could not add hotel");
        }

        [HttpGet]
        public ActionResult GetHotel() {
            string message=string.Empty;
            try
            {
                var result = _hotelService.GetHotels();
                return Ok(result);
                _logger.LogInformation("Displayed Hotels");
            }
            catch (NoHotelsAvailableException ex)
            {
                message = ex.Message;
            }
            return BadRequest(message);
            _logger.LogError("Could not display hotels");

        }
        [HttpPost("RemoveHotel")]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveHotel(int id)
        {
            var result = _hotelService.RemoveHotel(id);
            if (result)
            {
                return Ok("Hotel removed successfully");
                _logger.LogInformation("Hotel Removed");
            }
            return BadRequest("Could not remove hotel");
            _logger.LogError("Could not remove hotel");
        }
        [HttpPost("UpdateHotel")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateHotel(int id, HotelDTO hotelDTO)
        {
            var result = _hotelService.UpdateHotel(id, hotelDTO);
            if(result!= null)
            {
                return Ok(result);
                _logger.LogInformation("Hotel Updated");
            }
            return BadRequest("Could not update");
            _logger.LogError("Could not update hotel");
        }
    }
}
