using Microsoft.AspNet.Identity;
using SpacePlace.Models.Spaces;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
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
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(_service.CreateSpace(model));
        }

        public IHttpActionResult Get()
        {
            return Ok(_service.GetAllSpaces());
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            return Ok(_service.GetSpaceById(id));
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
