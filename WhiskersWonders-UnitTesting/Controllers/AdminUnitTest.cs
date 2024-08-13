using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskersWondersPets.Controllers;
using WhiskersWondersPets.Models;
using WhiskersWondersPets.Repository;

namespace WhiskersWonders_UnitTesting.Controllers
{
    [TestClass]
    public class AdminUnitTest
    {
        private Mock<IRepository>? _mockAnimalRepository;
        private AdminController? _adminController;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockAnimalRepository = new Mock<IRepository>();
            _mockAnimalRepository.Setup(repo => repo.GetCategories()).Returns(new Category[] {
                 new Category { CategoryId = 1, Name = "Mamal" },
                 new Category { CategoryId = 2, Name = "Reptile" },
            });
            _mockAnimalRepository.Setup(repo => repo.GetAnimals()).Returns(new Animal[] {
                  new Animal { AnimalId = 1, Name = "Cat", Age = 12, PictureName = "images/Cat.jpg", Description = "The cat, commonly referred to as the domestic cat or house cat, is a small domesticated carnivorous mammal. It is the only domesticated species of the family Felidae. Recent advances in archaeology and genetics have shown that the domestication of the cat occurred in the Near East around 7500 BC. It is commonly kept as a house pet and farm cat, but also ranges freely as a feral cat avoiding human contact. Valued by humans for companionship and its ability to kill vermin, the cat's retractable claws are adapted to killing small prey like mice and rats. It has a strong, flexible body, quick reflexes, and sharp teeth, and its night vision and sense of smell are well developed. It is a social species, but a solitary hunter and a crepuscular predator. Cat communication includes vocalizations like meowing, purring, trilling, hissing, growling, and grunting as well as cat body language. It can hear sounds too faint or too high in frequency for human ears, such as those made by small mammals. It secretes and perceives pheromones.", CategoryId = 1 },
                    new Animal { AnimalId = 2, Name = "Dog", Age = 12, PictureName = "images/Dog.jpg", Description = "The dog is a domesticated descendant of the wolf. Also called the domestic dog, it was domesticated from an extinct population of Pleistocene wolves over 14,000 years ago. The dog was the first species to be domesticated by humans. Experts estimate that hunter-gatherers domesticated dogs more than 15,000 years ago, which was before the development of agriculture. Due to their long association with humans, dogs have expanded to a large number of domestic individuals and gained the ability to thrive on a starch-rich diet that would be inadequate for other canids.", CategoryId = 1 },
            });

            _mockAnimalRepository.Setup(repo => repo.GetAnimal(1))
               .Returns(new Animal
               {
                   AnimalId = 1,
                   Name = "Cat",
                   Age = 12,
                   PictureName = "images/Cat.jpg",
                   Description = "The cat, commonly referred to as the domestic cat or house cat, is a small domesticated carnivorous mammal. It is the only domesticated species of the family Felidae. Recent advances in archaeology and genetics have shown that the domestication of the cat occurred in the Near East around 7500 BC. It is commonly kept as a house pet and farm cat, but also ranges freely as a feral cat avoiding human contact. Valued by humans for companionship and its ability to kill vermin, the cat's retractable claws are adapted to killing small prey like mice and rats. It has a strong, flexible body, quick reflexes, and sharp teeth, and its night vision and sense of smell are well developed. It is a social species, but a solitary hunter and a crepuscular predator. Cat communication includes vocalizations like meowing, purring, trilling, hissing, growling, and grunting as well as cat body language. It can hear sounds too faint or too high in frequency for human ears, such as those made by small mammals. It secretes and perceives pheromones.",
                   CategoryId = 1,
                   Comments = new Comment[] {
                        new Comment { CommentId = 1, AnimalId = 1, UserComment = "Wow its a cat" }
                   }
               });

            _adminController = new AdminController(_mockAnimalRepository.Object);
        }

        [TestMethod]
        public void IndexTest()
        {
            var res = _adminController!.Index();

            Assert.IsInstanceOfType(res, typeof(ViewResult));
        }

        [TestMethod]
        public void IndexTest2() // Pass down a non existing category number
        {
            var res = _adminController!.Index(14);

            Assert.IsInstanceOfType(res, typeof(ViewResult));
        }

        [TestMethod]
        public void AnimalTest() // Pass down an existing animal Id
        {
            var res = _adminController!.Animal(1);
            Assert.IsInstanceOfType(res, typeof(ViewResult));
        }
        [TestMethod]
        public void AnimalTest2() // Pass down a non existing animal Id
        {
            var res = _adminController!.Animal(2);
            Assert.IsInstanceOfType(res, typeof(RedirectToActionResult));
        }
        [TestMethod]
        public void DeleteAnimalTest() // Pass down an existing animal Id
        {
            var res = _adminController!.DeleteAnimal(2);
            Assert.IsInstanceOfType(res, typeof(StatusCodeResult));
        }
        [TestMethod]
        public void DeleteAnimalTest2() // Pass down a non existing animal Id
        {
            var res = _adminController!.DeleteAnimal(4);
            Assert.IsInstanceOfType(res, typeof(StatusCodeResult));
        }
        [TestMethod]
        public void DeleteCommentTest()
        {
            var res = _adminController!.DeleteComment(1, 1);
            Assert.IsInstanceOfType(res, typeof(StatusCodeResult));
        }

    }
}
