using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly ILogger _logger;

        public RoomController(IRoomService roomService, ILogger<RoomController> logger)
        {
            _roomService = roomService;
            _logger = logger;
        }
        [HttpPost(" GetAvailableRooms")]
        public ActionResult GetAvailableRooms(int hotelId)
        {
            string errorMessage = "";
            try
            {
                var result = _roomService.GetRooms(hotelId);
                if (result != null)
                {
                    return Ok(result);
                    _logger.LogInformation("Rooms Displayed");
                }
            }
            catch(NoRoomsAvailableException e){
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
            _logger.LogError("Unable to display rooms");
        }
        [HttpPost("CreateRooms")]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRooms(RoomDTO roomDTO)
        {
            var room = _roomService.AddRoom(roomDTO);
            if(room != null)
            {
                return Ok(room);
                _logger.LogInformation("Room Created");
            }
            return BadRequest("Could not add rooms");
            _logger.LogError("Unable to add room");
        }
        [HttpDelete("DeleteRooms")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRooms(int id)
        { 
            bool roomId = _roomService.RemoveRoom(id);
            if (roomId)
            {
                return Ok("The room has been deleted successfully");
                _logger.LogInformation("Room Deleted");
            }
            return BadRequest("Invalid roomId");
            _logger.LogError("Unable to delete room");
        }
        [HttpPost("PromoteRooms")]
        [Authorize(Roles = "Admin")]
        public ActionResult PromoteRooms(int id,RoomDTO roomDTO)
        {
            var room = _roomService.UpdateRoom(id,roomDTO);
            if (room != null)
            {
                return Ok("Room updated successfully");
                _logger.LogInformation("Room Updated");
            }
            return BadRequest("Unable to update");
            _logger.LogError("Unable to update room");
        }
    }
}
