using SpacePlace.Models.SpaceAmenities;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class SpaceAmenityController : ApiController
    {
        private readonly SpaceAmenityService _service = new SpaceAmenityService();

        public IHttpActionResult Post([FromBody] SpaceAmenityCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_service.CreateSpaceAmenity(model));
        }

        public IHttpActionResult Get()
        {
            var response = _service.GetAllSpaceAmmenities();
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        public IHttpActionResult Get([FromUri] string id)
        {
            var response = _service.GetSpaceAmenityById(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        public IHttpActionResult Put([FromBody] SpaceAmenityEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = _service.GetSpaceAmenityById(model.Id);
            if (response == null)
                return NotFound();

            if (_service.UpdateSpaceAmenity(model))
                return Ok();
            return InternalServerError();
        }

        public IHttpActionResult Delete([FromUri] string id)
        {
            var response = _service.GetSpaceAmenityById(id);
            if (response == null)
                return NotFound();
            if (_service.DeleteSpaceAmenity(id))
                return Ok();
            return InternalServerError();
        }
    }
}
