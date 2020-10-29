using SpacePlace.Models.Ratings;
using SpacePlace.Services;
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
        public IHttpActionResult Get([FromUri] RatingSearchParams spaceID)
        {
            return Ok(_service.GetAllRatings(spaceID));
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
