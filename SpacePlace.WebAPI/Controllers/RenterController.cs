﻿using SpacePlace.Models;
using SpacePlace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class RenterController : ApiController
    {
        private readonly RenterService _service = new RenterService();

        // post -- create
        public IHttpActionResult Post(RenterCreate model)
        {
            if (ModelState.IsValid)
            {
                if (_service.CreateRenter(model))
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