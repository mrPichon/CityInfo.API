using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        //public static CitiesDataStore Current { get; set; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            // init dummy data
             Cities = new List<CityDto>()
             {
                 new CityDto() { 
                     Id = 1,
                     Name ="New York City", 
                     Description ="The one with that big park",
                     PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Id = 1,
                             Name ="Central Park",
                             Description ="The most visited urban park in the United States.",
                         },
                         new PointOfInterestDto() {
                             Id = 2,
                             Name ="Empire State Building",
                             Description ="A 102-story skyscraper located in Midtown Manhattan.",
                         }
                     }
                 },
                 new CityDto() { 
                     Id = 2,
                     Name ="Jaisco", 
                     Description ="yey"
                 },
                 new CityDto() { 
                     Id = 3,
                     Name ="Paris", 
                     Description ="The one with that big tower",
                     PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Id = 1,
                             Name ="Eiffel Tower",
                             Description ="A wrought iron lattice tower on the Champ of Mars",
                         },
                         new PointOfInterestDto() {
                             Id = 2,
                             Name ="The Louvre",
                             Description ="The world's largest museum.",
                         }
                     }
                 }
             };
        }
    }
}
