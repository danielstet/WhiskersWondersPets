

using WhiskersWondersPets.Data;
using WhiskersWondersPets.Models;

namespace WhiskersWondersPets.Repository
{
    public class AnimalsRepo : IRepository
    {
        private AnimalsDBContext _animalsDBContext;
        public AnimalsRepo(AnimalsDBContext animalsDBContext) : base()                             
        {
            _animalsDBContext = animalsDBContext;
        }

        public void DeleteAnimal(int id)
        {
            var animal = _animalsDBContext.Animals!.Single(a => a.AnimalId.Equals(id));
            _animalsDBContext.Animals!.Remove(animal);
            _animalsDBContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _animalsDBContext.Categories!.Single(c => c.Equals(id));
            _animalsDBContext.Categories!.Remove(category);
            _animalsDBContext.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = _animalsDBContext.Comments!.Single(c => c.Equals(id));
            _animalsDBContext.Comments!.Remove(comment);
            _animalsDBContext.SaveChanges();
        }

        public ICollection<Animal> GetAnimals()
        {
            return _animalsDBContext.Animals!.ToList();
        }

        public ICollection<Animal> GetMostPopular()
        {
            try
            {
                ICollection<Animal> MostPopular = _animalsDBContext.Animals!.OrderByDescending(a => a.Comments!.Count).Take(2).ToList();
                return MostPopular;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ICollection<Category> GetCategories()
        {
            return _animalsDBContext.Categories!.ToList();
        }

        public ICollection<Comment> GetComments()
        {
            return _animalsDBContext.Comments!.ToList();
        }

        public void InsertAnimal(string animalName, string animalAge, string filePath, string description, string category)
        {
            int.TryParse(animalAge, out int age);
            int.TryParse(category, out int categoryId);
            var Id = _animalsDBContext.Animals.OrderBy(a => a.AnimalId).Last().AnimalId;
            Animal animal = new Animal() 
            { 
                AnimalId = ++Id,
                Name = animalName,
                Age = age,
                PictureName = filePath,
                Description = description,
                CategoryId = categoryId
            };
            _animalsDBContext.Add(animal);
            _animalsDBContext.SaveChanges();
        }

        public void InsertCategory(Category category)
        {
            _animalsDBContext.Add(category);
            _animalsDBContext.SaveChanges();
        }

        public void InsertComment(Animal animal,string NewComment)
        {

            List<Comment> CommentList = _animalsDBContext.Comments!.ToList();
            int LastComment = CommentList.Last().CommentId;
            Comment comment = new Comment() {
                CommentId = ++LastComment,
                AnimalId = animal.AnimalId,
                UserComment = NewComment,
                Animal = animal,
            };
            _animalsDBContext.Add(comment);
            _animalsDBContext.SaveChanges();
        }

        public void UpdateAnimal(int id, string animalName, string animalAge, string pictureName, string description, string category)
        {
            int.TryParse(animalAge, out  int age);
            int.TryParse(category, out int categoryId);
            var animalInDB = _animalsDBContext.Animals!.Single(c => c.AnimalId.Equals(id));
            animalInDB.Name = animalName;
            animalInDB.Age = age;
            animalInDB.PictureName = pictureName;
            animalInDB.Description =description;
            animalInDB.CategoryId = categoryId;
            _animalsDBContext.SaveChanges();
        }

        public void UpdateCategoty(int id, Category category)
        {
            var categoryInDB = _animalsDBContext.Categories!.Single(c => c.Equals(category));
            categoryInDB.Name = category.Name;
            _animalsDBContext.SaveChanges();
        }

        public void UpdateComment(int id, Comment comment)
        {
            var commentInDB = _animalsDBContext.Comments!.Single(c => c.Equals(comment));
            commentInDB.UserComment = comment.UserComment;
            _animalsDBContext.SaveChanges();
        }

        public Animal GetAnimal(int id)
        {
            var animal = _animalsDBContext.Animals!.Single(a => a.AnimalId.Equals(id));
            return animal;
        }
    }
}
