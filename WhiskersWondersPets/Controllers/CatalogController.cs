using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WhiskersWondersPets.Models;
using WhiskersWondersPets.Repository;

namespace WhiskersWondersPets.Controllers
{
    public class CatalogController : Controller
    {
        private IRepository _animalRepository;
        public CatalogController(IRepository animalRepository)
        {
            _animalRepository = animalRepository;
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
                Console.WriteLine(err);
                return Content("Somethinw went wrong");
            }
        }

        public IActionResult Animal(int id) {
            try
            {
                Animal animal = _animalRepository.GetAnimal(id);
                ViewBag.Animal = animal;

                List<Comment> comments = animal.Comments!.ToList();
                ViewBag.CommentsList = comments;

                int CommentsListLength = comments.Count;
                ViewBag.CommentsListLength = CommentsListLength;
                return View();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return RedirectToAction("PageNotFound");
            }
        }

        public IActionResult AddCommnet(int id, string NewComment) {
            try
            {
                var animal = _animalRepository.GetAnimal(id);
                _animalRepository.InsertComment(animal, NewComment);
                string URL = $"/Catalog/Animal?id={animal.AnimalId}";
                return Redirect(URL);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return Content("Somethinw went wrong");
            }
        }

        public IActionResult PageNotFound() {
            return View(); 
        }

    }
}
