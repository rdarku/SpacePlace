using SpacePlace.Models.Bookings;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class BookingController : ApiController
    {
        private readonly BookingService _service = new BookingService();

        [HttpPost]
        public IHttpActionResult Post(BookingCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_service.CreateBooking(model))
                return Ok();
            return InternalServerError();
            
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var response = _service.GetAllBookings();
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        //Get -- By ID
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var response = _service.GetBookingById(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        //// GET amenities with booking ID
        //[HttpGet]
        //public IHttpActionResult GetW([FromUri] int id)
        //{
        //    var response = _service.GetBookingByIdWithAmenities(id);
        //    if (response == null)
        //        return NotFound();
        //    return Ok(response);
        //}

        [HttpPut]
        public IHttpActionResult Put([FromBody] BookingEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = _service.GetBookingById(model.Id);
            if (item == null)
                return NotFound();
            if (_service.UpdateBooking(model))
                return Ok();
            return InternalServerError();
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var item = _service.GetBookingById(id);
            if (item == null)
                return NotFound();
            if(_service.CancelBooking(id))
                return Ok();
            return InternalServerError();
        }
    }
}
