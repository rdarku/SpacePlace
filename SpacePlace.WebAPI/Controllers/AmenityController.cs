using SpacePlace.Data;
using SpacePlace.Models.Amenities;
using SpacePlace.Services;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

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
            var response = _service.GetAllAmenities();
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        //Get -- By ID
        public IHttpActionResult Get([FromUri] int id)
        {
            var response =_service.GetAmenityById(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        //Put -- Update
        public IHttpActionResult Put([FromBody] AmenityEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.UpdateAmenity(model))
                return Ok();

            return BadRequest();
        }


        //Delete -- Remove
        public IHttpActionResult Delete([FromUri] int id)
        {
            AmenityListItem item = _service.GetAmenityById(id);
            if(item == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No amenity with ID = {0}", id)),
                        ReasonPhrase = "Amenity ID Not Found"
                    };
                throw new HttpResponseException(resp);
            }
            return Ok(_service.DeleteAmenity(id));
        }
    }
}
