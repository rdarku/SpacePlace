using Microsoft.AspNet.Identity;
using SpacePlace.Models.SpaceOwner;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class SpaceOwnerController : ApiController
    {
        private readonly SpaceOwnerService _service = new SpaceOwnerService();
        
        public IHttpActionResult Post()
        {
            SpaceOwnerCreate model = new SpaceOwnerCreate { SpaceOwnerId = User.Identity.GetUserId() };

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_service.CreateSpaceOwner(model))
                return Ok();
            return InternalServerError();
        }

        public IHttpActionResult Get()
        {
            var response = _service.GetAllOwners();
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            var response = _service.GetOwnerById(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}
