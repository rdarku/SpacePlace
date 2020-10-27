using SpacePlace.Models.SpaceOwner;
using SpacePlace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    public class SpaceOwnerController : ApiController
    {
        private readonly SpaceOwnerService _service = new SpaceOwnerService();
        
        // post -- create
        public IHttpActionResult Post(SpaceOwnerCreate model)
        {
            if (!ModelState.IsValid)
            {
                if (_service.CreateSpaceOwner(model))
                    return Ok();
                return InternalServerError();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //get -- list

        //get -- by ID

        // put -- update

        // delete -- remove
    }
}
