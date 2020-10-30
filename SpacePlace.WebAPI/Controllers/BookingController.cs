using SpacePlace.Models.Bookings;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class BookingController : ApiController
    {
        private readonly BookingService _service = new BookingService();

        //Post -- Create
        public IHttpActionResult Post(BookingCreate model)
        {
            if (ModelState.IsValid)
            {
                if (_service.CreateBooking(model))
                    return Ok();
                return InternalServerError();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //Get -- List
        public IHttpActionResult Get()
        {
            var response = _service.GetAllBookings();
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        //Get -- By ID
        public IHttpActionResult Get([FromUri] int id)
        {
            var response = _service.GetBookingById(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        //Put -- Update
        public IHttpActionResult Put([FromBody] BookingEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.UpdateBooking(model))
                return Ok();

            return BadRequest();
        }

        //Delete -- Remove
        public IHttpActionResult Delete([FromUri]int id)
        {
            return Ok(_service.CancelBooking(id));
        }
    }
}
