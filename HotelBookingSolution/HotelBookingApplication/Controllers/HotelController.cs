using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HotelBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger _logger;

        public HotelController(IHotelService hotelService, ILogger<HotelController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }
        /// <summary>
        /// Add the hotel 
        /// </summary>
        /// <param name="hotelDTO">Details of hotel to be added</param>
        /// <returns>Details of hotel</returns>
        [HttpPost("AddHotel")]
        //[Authorize(Roles ="Admin")]
        public ActionResult AddHotel([FromForm] IFormCollection data )
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
            HotelDTO hotelDTO = JsonConvert.DeserializeObject<HotelDTO>(json);
            hotelDTO.Image = file;

            string message = string.Empty;
            try
            {


                var hotel = _hotelService.AddHotel(hotelDTO);
                if (hotel != null)
                {
                    _logger.LogInformation("Hotel Added");
                    return Ok(hotel);
                }
                message = "Could not add hotel";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            _logger.LogError("Could not add hotel");
            return BadRequest(message);
        }
        /// <summary>
        /// Get the details of hotel
        /// </summary>
        /// <param name="city">city to be filter</param>
        /// <returns>Display the hotel based on city</returns>
        [HttpGet]
        public ActionResult GetHotel(string city) {
            string message=string.Empty;
            try
            {
                var result = _hotelService.GetHotels(city);
                _logger.LogInformation("Displayed Hotels");
                return Ok(result);
                
            }
            catch (NoHotelsAvailableException ex)
            {
                message = ex.Message;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            _logger.LogError("Could not display hotels");
            return BadRequest(message);
        }
        /// <summary>
        /// Delete the hotel
        /// </summary>
        /// <param name="id">Id of a hotel</param>
        /// <returns>Return a message</returns>
        [HttpDelete("RemoveHotel")]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveHotel(int id)
        {
            string message = string.Empty;
            try
            {
                var result = _hotelService.RemoveHotel(id);
                if (result)
                {
                    _logger.LogInformation("Hotel Removed");
                    return Ok("Hotel removed successfully");
                }
                message = "Could not delete hotel";
            }catch(Exception e)
            {
                message = e.Message;
            }
            
            _logger.LogError("Could not remove hotel");
            return BadRequest(message);
            
        }
        /// <summary>
        /// Update the hotel details
        /// </summary>
        /// <param name="id">hotel id</param>
        /// <param name="hotelDTO">Inforamtion of hotel</param>
        /// <returns>updated message</returns>
        [HttpPost("UpdateHotel")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateHotel(int id, HotelDTO hotelDTO)
        {
            string message = string.Empty;
            try
            {
                var result = _hotelService.UpdateHotel(id, hotelDTO);
                if (result != null)
                {
                    _logger.LogInformation("Hotel Updated");
                    return Ok(result);
                }
                message = "Could not update hotel";
            }
            catch(Exception e)
            {
                message = e.Message;
            }
            _logger.LogError("Could not update hotel");
            return BadRequest(message);
            
        }
    }
}
