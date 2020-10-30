using SpacePlace.Models.SpaceAmenities;
using SpacePlace.Services;
using System.Net;
using System.Net.Http;
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
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record found"));
            }

            return Ok(response);
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            var response = _service.GetSpaceAmenityById(id);
            if (response == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record found"));
            }

            return Ok(response);
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
