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
        [HttpPost]
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
        [HttpGet]
        public IHttpActionResult Get()
        {
            var response = _service.GetAllBookings();
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        //Get -- By ID
        //[HttpGet]
        //public IHttpActionResult Get([FromUri] int id)
        //{
        //    var response = _service.GetBookingById(id);
        //    if(response == null)
        //    {
        //        throw new HttpResponseException(
        //            Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record found"));
        //    }

        //    return Ok(response);
        //}

        //// GET amenities with booking ID
        [HttpGet]
        public IHttpActionResult GetW([FromUri] int id)
        {

            var response = _service.GetBookingByIdWithAmenities(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        //Put -- Update
        [HttpPut]
        public IHttpActionResult Put([FromBody] BookingEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BookingListItem item = _service.GetBookingById(model.Id);
            if (item == null)
                return NotFound();

            if (_service.UpdateBooking(model))
                return Ok();
            return InternalServerError();
        }

        //Delete -- Remove
        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            BookingListItem item = _service.GetBookingById(id);
            if (item == null)
                return NotFound();
            if(_service.CancelBooking(id))
                return Ok();
            return InternalServerError();
        }
    }
}
