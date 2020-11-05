using SpacePlace.Models.SpaceAmenities;
using SpacePlace.Services;
using System;
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
            if (_service.CreateSpaceAmenity(model))
                return Ok();
            return InternalServerError();
        }

        public IHttpActionResult Get()
        {
            var response = _service.GetAllSpaceAmmenities();
            if (response == null)
                return (IHttpActionResult)Request.CreateResponse(
                    HttpStatusCode.NotFound,"No SpaceAmenity found");
            return Ok(response);
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            var response = _service.GetSpaceAmenityById(id);
            if (response == null)
                return (IHttpActionResult)Request.CreateResponse(
                    HttpStatusCode.NotFound,
                    string.Format("SpaceAmenity with ID = {0} not found", id));
            return Ok(response);
        }

        public IHttpActionResult Put([FromBody] SpaceAmenityEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = _service.GetSpaceAmenityById(model.Id);
            if (response == null)
                return (IHttpActionResult)Request.CreateResponse(
                    HttpStatusCode.NotFound, 
                    string.Format("SpaceAmenity with ID = {0} not found", model.Id));
            if (_service.UpdateSpaceAmenity(model))
                return Ok();
            return InternalServerError();
        }

        public IHttpActionResult Delete([FromUri] int id)
        {
            var response = _service.GetSpaceAmenityById(id);
            if (response == null)
                return (IHttpActionResult)Request.CreateResponse(
                    HttpStatusCode.NotFound,
                    string.Format("SpaceAmenity with ID = {0} not found", id.ToString()));
            if (_service.DeleteSpaceAmenity(id))
                return Ok();
            return InternalServerError();
        }
    }
}
