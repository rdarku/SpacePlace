using SpacePlace.Models.Categories;
using SpacePlace.Services;
using System.Web.Http;

namespace SpacePlace.WebAPI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private readonly CategoryService _service = new CategoryService();

        public IHttpActionResult Post(CategoryCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_service.CreateCategory(model))
                return Ok();
            return InternalServerError();
        }

        public IHttpActionResult Get()
        {
            var response = _service.GetAllCategories();
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            var response =_service.GetCategoryById(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

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
