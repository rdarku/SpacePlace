﻿using SpacePlace.Models.Categories;
using SpacePlace.Services;
using System.Web.Http;

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
            var response = _service.GetAllCategories();
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        // get -- by Id
        public IHttpActionResult Get([FromUri] int id)
        {
            var response =_service.GetCategoryById(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        // Put -- update
        public IHttpActionResult Put([FromBody] CategoryEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CategoryListItem item = _service.GetCategoryById(model.Id);
            if (item == null)
                return NotFound();
            if (_service.UpdateCategory(model))
                return Ok();
            return InternalServerError();
        }

        // delete -- remove
        public IHttpActionResult Delete([FromUri] int id)
        {
            CategoryListItem item = _service.GetCategoryById(id);
            if (item == null)
                return NotFound();
            if (_service.DeleteCategory(id))
                return Ok();
            return InternalServerError();
        }
    }
}
