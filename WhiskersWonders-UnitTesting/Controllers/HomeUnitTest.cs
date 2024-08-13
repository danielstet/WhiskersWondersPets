using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WhiskersWondersPets.Controllers;
using WhiskersWondersPets.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WhiskersWondersPets.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace WhiskersWonders_UnitTesting.Controllers
{
    [TestClass]
    public class HomeUnitTest
    {
        private Mock<IRepository>? _mockAnimalRepository;
        private HomeController? _homeController;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            _mockAnimalRepository = new Mock<IRepository>();
            _mockAnimalRepository.Setup(repo => repo.GetMostPopular())
            .Returns(new List<Animal>
            {
                    new Animal { AnimalId = 1, Name = "Cat", Age = 12, PictureName = "images/Cat.jpg", Description = "The cat, commonly referred to as the domestic cat or house cat, is a small domesticated carnivorous mammal. It is the only domesticated species of the family Felidae. Recent advances in archaeology and genetics have shown that the domestication of the cat occurred in the Near East around 7500 BC. It is commonly kept as a house pet and farm cat, but also ranges freely as a feral cat avoiding human contact. Valued by humans for companionship and its ability to kill vermin, the cat's retractable claws are adapted to killing small prey like mice and rats. It has a strong, flexible body, quick reflexes, and sharp teeth, and its night vision and sense of smell are well developed. It is a social species, but a solitary hunter and a crepuscular predator. Cat communication includes vocalizations like meowing, purring, trilling, hissing, growling, and grunting as well as cat body language. It can hear sounds too faint or too high in frequency for human ears, such as those made by small mammals. It secretes and perceives pheromones.", CategoryId = 1 },
                    new Animal { AnimalId = 2, Name = "Dog", Age = 12, PictureName = "images/Dog.jpg", Description = "The dog is a domesticated descendant of the wolf. Also called the domestic dog, it was domesticated from an extinct population of Pleistocene wolves over 14,000 years ago. The dog was the first species to be domesticated by humans. Experts estimate that hunter-gatherers domesticated dogs more than 15,000 years ago, which was before the development of agriculture. Due to their long association with humans, dogs have expanded to a large number of domestic individuals and gained the ability to thrive on a starch-rich diet that would be inadequate for other canids.", CategoryId = 1 },
            });

            _homeController = new HomeController(_mockAnimalRepository.Object);

        }

        [TestMethod]
        public void IndexTest()
        {

            // Act
            var res = _homeController!.Index() as ViewResult;
            // Assert
            Assert.IsInstanceOfType(res, typeof(ViewResult));
        }
    }
}