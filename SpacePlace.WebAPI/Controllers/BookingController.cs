using SpacePlace.Models.Bookings;
using SpacePlace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
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
            return Ok(_service.GetAllBookings());
        }

        //Get -- By ID

        //Put -- Update

        //Delete -- Remove
    }
}
