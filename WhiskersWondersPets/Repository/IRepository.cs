using System;
using WhiskersWondersPets.Models;

namespace WhiskersWondersPets.Repository
{
    public interface IRepository
    {
        ICollection<Animal> GetAnimals();
        ICollection<Animal> GetMostPopular();
        Animal GetAnimal(int id);
        void InsertAnimal(string animalName, string animalAge, string pictureName, string description, string category);
        void UpdateAnimal(int id, string animalName, string animalAge, string pictureName, string description, string category);
        void DeleteAnimal(int id);

        ICollection<Category> GetCategories();
        void InsertCategory(Category category);
        void UpdateCategoty(int id, Category category);
        void DeleteCategory(int id);

        ICollection<Comment> GetComments();
        void InsertComment(Animal animal, string NewComment);
        void UpdateComment(int id, Comment comment);
        void DeleteComment(int id);
    }
}
