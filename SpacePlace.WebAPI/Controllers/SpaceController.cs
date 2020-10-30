using Microsoft.AspNet.Identity;
using SpacePlace.Models.Spaces;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class SpaceController : ApiController
    {
        private readonly SpaceService _service;

        public SpaceController()
        {
            var userId = User.Identity.GetUserId();

            _service = new SpaceService(userId);
        }

        public IHttpActionResult Post([FromBody] SpaceCreate model)
        {
            var user = User.Identity.GetUserId();

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(_service.CreateSpace(model, user));
        }

        public IHttpActionResult Get([FromUri] SpaceSearchParams searchParams) 
        {
            var response =_service.GetAllSpaces(searchParams);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            var response = _service.GetSpaceById(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        public IHttpActionResult Put([FromBody] SpaceEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_service.UpdateSpace(model));
        }

        public IHttpActionResult Delete([FromUri] int id)
        {
            return Ok(_service.ArchiveSpace(id));
        }
    }
}
