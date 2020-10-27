﻿using SpacePlace.Models.Categories;
using SpacePlace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Razor.Parser;

namespace SpacePlace.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly CategoryService _service = new CategoryService();

        // post -- create
        public IHttpActionResult Post(CategoryCreate model)
        {
            if (!ModelState.IsValid)
            {
                if (_service.CreateCategory(model))
                    return Ok();

                return InternalServerError();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // get -- list

        // get -- by Id

        // Put -- update

        // delete -- remove
    }
}