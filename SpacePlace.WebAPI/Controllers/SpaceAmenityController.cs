using SpacePlace.Models.SpaceAmenities;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
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
            return Ok(_service.GetAllSpaceAmmenities());
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            return Ok(_service.GetSpaceAmenityById(id));
        }

        public IHttpActionResult Put([FromBody] SpaceAmenityEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_service.UpdateSpaceAmenity(model));
        }

        public IHttpActionResult Delete([FromUri] int id)
        {
            return Ok(_service.DeleteSpaceAmenity(id));
        }
    }
}
