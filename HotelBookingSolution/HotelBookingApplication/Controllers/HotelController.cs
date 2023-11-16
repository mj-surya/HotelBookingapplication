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
                _logger.LogInformation("Hotel Added");
                return Ok(hotel);
            }
            _logger.LogError("Could not add hotel");
            return BadRequest("Could not add hotel");
            
        }

        [HttpGet]
        public ActionResult GetHotel() {
            string message=string.Empty;
            try
            {
                var result = _hotelService.GetHotels();
                _logger.LogInformation("Displayed Hotels");
                return Ok(result);
                
            }
            catch (NoHotelsAvailableException ex)
            {
                message = ex.Message;
            }
            _logger.LogError("Could not display hotels");
            return BadRequest(message);
            

        }
        [HttpPost("RemoveHotel")]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveHotel(int id)
        {
            var result = _hotelService.RemoveHotel(id);
            if (result)
            {
                _logger.LogInformation("Hotel Removed");
                return Ok("Hotel removed successfully");
                
            }
            _logger.LogError("Could not remove hotel");
            return BadRequest("Could not remove hotel");
            
        }
        [HttpPost("UpdateHotel")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateHotel(int id, HotelDTO hotelDTO)
        {
            var result = _hotelService.UpdateHotel(id, hotelDTO);
            if(result!= null)
            {
                _logger.LogInformation("Hotel Updated");
                return Ok(result);
                
            }
            _logger.LogError("Could not update hotel");
            return BadRequest("Could not update");
            
        }
    }
}
