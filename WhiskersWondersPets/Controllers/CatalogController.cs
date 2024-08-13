using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WhiskersWondersPets.Models;
using WhiskersWondersPets.Repository;

namespace WhiskersWondersPets.Controllers
{
    public class CatalogController : Controller
    {
        private IRepository _animalRepository;
        private readonly ILogger _logger;
        public CatalogController(IRepository animalRepository, ILogger<CatalogController> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
            _logger.LogDebug("Nlog is intergrated to Catalog Controller");
        }


        public IActionResult Index(int? CategoryNumber = 0)
        {
            try
            {
                List<Animal> animals = new List<Animal>();
                if (CategoryNumber == 0)
                {
                    animals = _animalRepository.GetAnimals().ToList();
                }
                else
                {
                    animals = _animalRepository.GetAnimals().Where(a => a.CategoryId.Equals(CategoryNumber)).ToList();
                }
                List<Category> categories = _animalRepository.GetCategories().ToList();
                Category All = new Category() {
                    CategoryId = 0,
                    Name = "All"
                };
                categories.Add(All);
                ViewBag.animalListLength = animals.Count;
                ViewBag.CategoriesListLength = categories.Count;
                ViewBag.AnimalsList = animals;
                ViewBag.CategoriesList = categories;
                ViewBag.CategoryNumber = CategoryNumber;
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        // Ask for help!
        public IActionResult Animal(int id)
        {
            try
            {
                Animal animal = _animalRepository.GetAnimal(id);
                List<Comment> comments = animal.Comments!.ToList();
                ViewBag.CommentsList = comments;
                int CommentsListLength = comments.Count;
                ViewBag.CommentsListLength = CommentsListLength;
                return View(animal);
            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);
                return RedirectToAction("PageNotFound");
            }
        }


        public IActionResult AddCommnet(int id, string NewComment)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NewComment))
                    throw new Exception("Comment was null");

                var animal = _animalRepository.GetAnimal(id);
                _animalRepository.InsertComment(animal, NewComment);
                int AnimalId = animal.AnimalId;
                return StatusCode(200);
          
            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);
                return StatusCode(500);
            }
        }

        public IActionResult PageNotFound() {
            return View(); 
        }

    }
}
