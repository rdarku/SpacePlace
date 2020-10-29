using SpacePlace.Models.Ratings;
using SpacePlace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    public class RatingController : ApiController
    {
        private readonly RatingService _service = new RatingService();

        // post -- create
        public IHttpActionResult Post(RatingCreate model)
        {
            if (ModelState.IsValid)
            {
                if (_service.CreateRating(model))
                    return Ok();

                return InternalServerError();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // get -- list
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAllRatings());
        }

        // get -- by Id
        public IHttpActionResult Get([FromUri] int id)
        {
            return Ok(_service.GetRatingById(id));
        }

        // Put -- update -- we are not allowing at this time
        //Remove -- we are not allowing at this time

    }
}
