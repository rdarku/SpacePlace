﻿using SpacePlace.Models.Amenities;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class AmenityController : ApiController
    {
        private readonly AmenityService _service = new AmenityService();

        //Post -- Create
        public IHttpActionResult Post(AmenityCreate model)
        {
            if (ModelState.IsValid)
            {           
                if (_service.CreateAmenity(model))
                    return Ok();
                return InternalServerError();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //Get -- <List>
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAllAmenities());
        }

        //Get -- By ID
        public IHttpActionResult Get([FromUri] int id)
        {
            return Ok(_service.GetAmenityById(id));
        }

        //Put -- Update

        //Delete -- Remove
    }
}
