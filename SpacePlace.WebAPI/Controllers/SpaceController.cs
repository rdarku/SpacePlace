﻿using Microsoft.AspNet.Identity;
using SpacePlace.Models.Spaces;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class SpaceController : ApiController
    {
        private readonly SpaceService _service = new SpaceService();

        public IHttpActionResult Post([FromBody] SpaceCreate model)
        {
            var user = User.Identity.GetUserId();

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            if(_service.CreateSpace(model, user))
                return Ok();
            return InternalServerError();
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
            var response = _service.GetSpaceById(model.Id);
            if (response == null)
                return NotFound();
            if (_service.UpdateSpace(model))
                return Ok();
            return InternalServerError();
        }

        public IHttpActionResult Delete([FromUri] int id)
        {
            var response = _service.GetSpaceById(id);
            if (response == null)
                return NotFound();
            if (_service.ArchiveSpace(id))
                return Ok();
            return InternalServerError();
        }
    }
}
