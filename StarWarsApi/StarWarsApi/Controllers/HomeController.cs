using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarWarsApi.Models;
using System.Diagnostics;


namespace StarWarsApi.Controllers
{

    public class HomeController : Controller
    {
        private StarShipContext context { get; set; }

        public HomeController (StarShipContext ctx) => context = ctx;
        
        public IActionResult Index()
        {
            var starships = context.Starships.OrderBy(s => s.name).ToList();
            return View(starships);
        }
    }


    public static class StarshipSeeder
    {

        public static async Task SeedStarShipData(StarShipContext context)
        {
            if (context.Starships.Any())
            {
                return; // Data already seeded
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://swapi.dev/api/starships/?format=json");
            var apiResponse = await response.Content.ReadAsStringAsync();

            var starshipApiResponse = JsonConvert.DeserializeObject<StarshipApiResponse>(apiResponse);
            var starships = starshipApiResponse.Results;

            context.Starships.AddRange(starships);
            await context.SaveChangesAsync();
        }
    }

}
