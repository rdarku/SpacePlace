using SpacePlace.Models.Bookings;
using SpacePlace.Services;
using System.Net;
using System.Net.Http;
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
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record found"));
            }

            return Ok(response);
        }

        //Get -- By ID
        public IHttpActionResult Get([FromUri] int id)
        {
            var response = _service.GetBookingById(id);
            if(response == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record found"));
            }

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
            BookingListItem item = _service.GetBookingById(id);
            if (item == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No booking with ID = {0}", id)),
                    ReasonPhrase = "Booking ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(_service.CancelBooking(id));
        }
    }
}
