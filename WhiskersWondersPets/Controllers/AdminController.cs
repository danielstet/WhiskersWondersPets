using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhiskersWondersPets.Models;
using WhiskersWondersPets.Repository;

namespace WhiskersWondersPets.Controllers
{
    [Authorize(Roles = "Admin")]
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
                Category All = new Category()
                {
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
            catch (Exception)
            {
                // Should I Log it?
                // In what scenario can it even get exception? DataBase problems maybe?

               return RedirectToAction("Index", "Home");
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
            catch (Exception)
            {
                return RedirectToAction("PageNotFound", "Catalog");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Index(string animalName, string animalAge, IFormFile pictureName, string description, string category)
        {
            bool valid = validateAnimal(animalName,animalAge,pictureName,description,category);
            if (pictureName != null && pictureName.Length > 0 && valid)
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
                    return StatusCode(500);
                }
            }
            return StatusCode(200);
        }

        private bool validateAnimal( string animalName, string animalAge, IFormFile formFile, string description, string category)
        {
            int.TryParse(category, out int categoryId);
            int.TryParse(animalAge, out int Age);
            int categoriesNum = _animalRepository.GetCategories().ToList().Count();
            bool Valid = true;
            if (string.IsNullOrWhiteSpace(animalName)) { Valid = false; }
            else if (string.IsNullOrWhiteSpace(animalAge) || Age <= 0) { Valid = false; }
            else if (formFile == null || formFile.FileName.Contains("exe")) { Valid = false; }
            else if (description == null || description.Length == 0) { Valid = false; }
            else if (categoryId < 0 || categoryId > categoriesNum) { Valid = false; }
            return Valid;
        }


        public IActionResult DeleteAnimal(int id)
        {
            try
            {
                _animalRepository.DeleteAnimal(id);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public IActionResult DeleteComment(int id, int AnimalId) {
            try
            {
                _animalRepository.DeleteComment(id);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        
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
                return StatusCode(200);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return StatusCode(500);
            }

            
        }

    }
}
