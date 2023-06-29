using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);            
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            var citiToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (citiToReturn == null)
            {
                return NotFound();
            }
            return Ok(citiToReturn);
        }
    }
}
