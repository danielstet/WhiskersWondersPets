using Microsoft.AspNetCore.Mvc;
using WhiskersWondersPets.Models;
using WhiskersWondersPets.Repository;

namespace WhiskersWondersPets.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _animalRepository;
        public AdminController(IRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }


        [HttpGet]
        public IActionResult Index(int? CategoryNumber = 0)
        {
            try
            {
                List<Category> categories = _animalRepository.GetCategories().ToList();
                ViewBag.CategoriesListLength = categories.Count;
                ViewBag.CategoriesList = categories;

                List<Animal> animals = new List<Animal>();
                if (CategoryNumber == 0)
                {
                    animals = _animalRepository.GetAnimals().ToList();
                }
                else
                {
                    animals = _animalRepository.GetAnimals().Where(a => a.CategoryId.Equals(CategoryNumber)).ToList();
                }
                ViewBag.animalListLength = animals.Count;
                ViewBag.AnimalsList = animals;

                return View();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return Content("Something went wrong");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Index(string animalName, string animalAge, IFormFile pictureName, string description, string category)
        {
            if (pictureName != null && pictureName.Length > 0)
            {
                string RandomNums = Guid.NewGuid().ToString();
                string PhotoNewName = $"{RandomNums.Remove(16)}_{pictureName.FileName}";
                // Save file to a directory or handle it
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", PhotoNewName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await pictureName.CopyToAsync(stream);
                }
                filePath = Path.Combine("images", PhotoNewName);

                try
                {
                    _animalRepository.InsertAnimal(animalName, animalAge, filePath, description, category);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            }

            return RedirectToAction("Index");
        }


        [HttpDelete]
        public IActionResult DeleteAnimal(int id)
        {
            try
            {
                _animalRepository.DeleteAnimal(id);
                return RedirectToAction("Index");

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return Content("Error, something went wrong");
            }
        }

        [HttpGet]
        public IActionResult Animal(int id)
        {
            try
            {
                Animal animal = _animalRepository.GetAnimal(id);
                ViewBag.Animal = animal;

                List<Comment> comments = animal.Comments!.ToList();
                ViewBag.CommentsList = comments;

                int CommentsListLength = comments.Count;
                ViewBag.CommentsListLength = CommentsListLength;

                List<Category> categories = _animalRepository.GetCategories().ToList();
                ViewBag.CategoriesListLength = categories.Count;
                ViewBag.CategoriesList = categories;

                return View(animal);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return Content("Error, something went wrong");
            }
            
        }

        // Maybe make Animal HttpPost instead
        [HttpPost]
        public async Task<IActionResult> UpdateAnimal(string animalId, string animalName, string animalAge, IFormFile pictureName, string description, string category)
        {
            try
            {
                string filePath = "";
                int.TryParse(animalId, out var id);

                if (pictureName != null && pictureName.Length > 0)
                {
                    string RandomNums = Guid.NewGuid().ToString();
                    string PhotoNewName = $"{RandomNums.Remove(16)}_{pictureName.FileName}";
                    // Save file to a directory or handle it
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", PhotoNewName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await pictureName.CopyToAsync(stream);
                    }
                    filePath = Path.Combine("images", PhotoNewName);
                }
                else
                {
                    Animal animal = _animalRepository.GetAnimal(id);
                    filePath = animal.PictureName;
                }
                _animalRepository.UpdateAnimal(id, animalName, animalAge, filePath, description, category);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return Content("Somethinw went wrong");
            }

            
        }

    }
}
