using Microsoft.AspNetCore.Mvc;
using WhiskersWondersPets.Data;
using WhiskersWondersPets.Models;
using WhiskersWondersPets.Repository;

namespace WhiskersWondersPets.Controllers
{
    public class HomeController : Controller
    {
      

        private IRepository _animalRepository;

        public HomeController(IRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                List<Animal> MostPopular = _animalRepository.GetMostPopular().ToList();
                bool isLoaded = true;
                ViewBag.MostPopular1 = MostPopular[0];
                ViewBag.MostPopular2 = MostPopular[1];
                ViewBag.List = MostPopular;
                ViewBag.isLoaded = isLoaded;
                return View();
            }
            catch (Exception)
            {
                bool isLoaded = false;
                ViewBag.isLoaded = isLoaded;
                return View();
            }            
        }

    }
}
