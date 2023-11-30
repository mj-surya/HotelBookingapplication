using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly ILogger _logger;

        public RoomController(IRoomService roomService, ILogger<RoomController> logger)
        {
            _roomService = roomService;
            _logger = logger;
        }
        /// <summary>
        /// Get the available rooms
        /// </summary>
        /// <param name="hotelId">id of hotel</param>
        /// <param name="checkIn">check in date</param>
        /// <param name="checkOut">check out date</param>
        /// <returns>Display the available room</returns>
        [HttpGet("GetAvailableRooms")]
        public ActionResult GetAvailableRooms(int hotelId,string checkIn, string checkOut)
        {
            string errorMessage = "";
            try
            {
                var result = _roomService.GetRooms(hotelId, checkIn, checkOut);
                if (result != null)
                {
                    _logger.LogInformation("Rooms Displayed");
                    return Ok(result);
                    
                }
            }
            catch(NoRoomsAvailableException e){
                errorMessage = e.Message;
            }
            catch(Exception e)
            {
                errorMessage = e.Message;
            }
            _logger.LogError("Unable to display rooms");
            return BadRequest(errorMessage);
            
        }
        /// <summary>
        /// Add the room to hotel
        /// </summary>
        /// <param name="roomDTO">information of room</param>
        /// <returns>the room details</returns>
        [HttpPost("CreateRooms")]
       // [Authorize(Roles = "Admin")]
        public ActionResult CreateRooms([FromForm] IFormCollection data)
        {
            IFormFile file = data.Files["image"];

            if (file != null && file.Length > 0)
            {
                string filename = file.FileName;
                string path = Path.Combine(@".\wwwroot\Images", filename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                        file.CopyTo(stream);
                }
            }
            string json = data["json"];
            RoomDTO roomDTO = JsonConvert.DeserializeObject<RoomDTO>(json);
            roomDTO.Picture = file;
            string message = string.Empty;
            try
            {
                var room = _roomService.AddRoom(roomDTO);
                if (room != null)
                {
                    _logger.LogInformation("Room Created");
                    return Ok(room);
                }
                message = "Could not add rooms";
            }
            catch(Exception e)
            {
                message = e.Message;
            }
            _logger.LogError("Unable to add room");
            return BadRequest(message);
            
        }
        /// <summary>
        /// Remove the room from hotel
        /// </summary>
        /// <param name="id">Room id</param>
        /// <returns>Deleted message</returns>
        [HttpDelete("DeleteRooms")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRooms(int id)
        {
            string message = string.Empty;
            try
            {
                bool roomId = _roomService.RemoveRoom(id);
                if (roomId)
                {
                    _logger.LogInformation("Room Deleted");
                    return Ok("The room has been deleted successfully");
                }
                message = "Invalid roomId";
            }
            catch(Exception e) { 
                message = e.Message;    
            }
            _logger.LogError("Unable to delete room");
            return BadRequest(message);
        }
        /// <summary>
        /// Update the room
        /// </summary>
        /// <param name="id">room id</param>
        /// <param name="roomDTO">Details of room</param>
        /// <returns>Display updated message</returns>
        [HttpPost("PromoteRooms")]
        [Authorize(Roles = "Admin")]
        public ActionResult PromoteRooms(int id,RoomDTO roomDTO)
        {
            string message = string.Empty;
            try
            {
                var room = _roomService.UpdateRoom(id, roomDTO);
                if (room != null)
                {
                    _logger.LogInformation("Room Updated");
                    return Ok("Room updated successfully");
                }
                message = "Unable to update";
            }
             catch(Exception e)
            {
                message = e.Message;    
            }
            _logger.LogError("Unable to update room");
            return BadRequest(message);
            
        }
    }
}
