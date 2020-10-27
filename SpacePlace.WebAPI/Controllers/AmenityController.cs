﻿using SpacePlace.Models.Amenities;
using SpacePlace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    public class AmenityController : ApiController
    {
        private readonly AmenityService _service = new AmenityService();

        //Post -- Create
        public IHttpActionResult Post(AmenityCreate model)
        {
            if (!ModelState.IsValid)
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

        //Get -- By ID

        //Put -- Update

        //Delete -- Remove
    }
}