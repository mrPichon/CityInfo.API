using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly CitiesDataStore _citiesDataStore;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            this._cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            //this._citiesDataStore = citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));
        }

        [HttpGet()]
        // to bound a [FromQuery(Name="filteronname")] string? name
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities([FromQuery] string? name)
        {
            var cityEntities = await _cityInfoRepository.GetCitiesAsync(name);
            var results = new List<CityWithoutPointsOfInterestDto>();
            // map
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }
            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }
            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
    }
}
