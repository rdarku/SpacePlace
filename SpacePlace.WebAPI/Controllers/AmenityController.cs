using SpacePlace.Models.Amenities;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class AmenityController : ApiController
    {
        private readonly AmenityService _service = new AmenityService();

        public IHttpActionResult Post(AmenityCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_service.CreateAmenity(model))
                return Ok();
            return InternalServerError();
        }

        public IHttpActionResult Get()
        {
            var response = _service.GetAllAmenities();
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            var response =_service.GetAmenityById(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        public IHttpActionResult Put([FromBody] AmenityEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_service.UpdateAmenity(model))
                return Ok();
            return BadRequest();
        }

        public IHttpActionResult Delete([FromUri] int id)
        {
            AmenityListItem item = _service.GetAmenityById(id);
            if (item == null)
                return NotFound();
            if(_service.DeleteAmenity(id))
                return Ok();
            return InternalServerError();
        }
    }
}
