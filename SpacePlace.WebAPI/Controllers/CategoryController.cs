using SpacePlace.Models.Categories;
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
    [Authorize]
    public class CategoryController : ApiController
    {
        private readonly CategoryService _service = new CategoryService();

        // post -- create
        public IHttpActionResult Post(CategoryCreate model)
        {
            if (ModelState.IsValid)
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
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAllCategories());
        }

        // get -- by Id
        public IHttpActionResult Get([FromUri] int id)
        {
            return Ok(_service.GetCategoryById(id));
        }

        // Put -- update
        public IHttpActionResult Put([FromBody] CategoryEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.UpdateCategory(model))
                return Ok();

            return BadRequest();
        }

        // delete -- remove
        public IHttpActionResult Delete([FromUri] int id)
        {
            return Ok(_service.DeleteCategory(id));
        }
    }
}
