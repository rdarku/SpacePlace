using SpacePlace.Models.Ratings;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
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
            var response =_service.GetAllRatings(spaceID);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        // get -- by Id
        public IHttpActionResult Get([FromUri] int id)
        {
            var response = _service.GetRatingById(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}
