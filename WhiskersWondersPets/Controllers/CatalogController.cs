using Microsoft.AspNetCore.Mvc;
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
                ViewBag.animalListLength = animals.Count;
                ViewBag.CategoriesListLength = categories.Count;
                ViewBag.AnimalsList = animals;
                ViewBag.CategoriesList = categories;
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
                return RedirectToAction("Index");
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
    }
}
