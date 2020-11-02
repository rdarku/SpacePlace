using SpacePlace.Models.Ratings;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class RatingController : ApiController
    {
        private readonly RatingService _service = new RatingService();

        public IHttpActionResult Post(RatingCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);          
            if (_service.CreateRating(model))
                return Ok();
            return InternalServerError();
        }

        public IHttpActionResult Get([FromUri] RatingSearchParams spaceID)
        {
            var response =_service.GetAllRatings(spaceID);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            var response = _service.GetRatingById(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}
