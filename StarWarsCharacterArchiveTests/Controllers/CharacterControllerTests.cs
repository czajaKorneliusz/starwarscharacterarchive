using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using StarWarsCharacterArchive.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsCharacterArchive.Controllers.Tests
{
    [TestFixture()]
    public class CharacterControllerTests
    {
        private CharacterController controller;
        private CharacterContext context;
        [SetUp]
        public void GlobalSetup()
        {
            DbContextOptions<CharacterContext> options = new DbContextOptionsBuilder<CharacterContext>()
            .UseInMemoryDatabase(databaseName: "StarWarsDatabase")
            .Options;
            context = new CharacterContext(options);
            context.Database.EnsureDeleted();
            NullLogger<CharacterController> myLogger = new NullLogger<CharacterController>();
            controller = new CharacterController(myLogger, context);
        }

        public void PopulateDataBase(int length = 5)
        {
            for (int i = 0; i < length; i++)
            {
                context.Add(new Character(i.ToString(), new List<string>(new string[] { "One", "Two" }), "planet", new List<string>(new string[] { "LeftFriend", "RightFriend" })));
            }
            context.SaveChanges();
        }

        [Test()]
        public void DeleteCharacterTest()
        {
            PopulateDataBase();
            Assert.IsTrue(context.Characters.Any(x => x.Name == "0"));
            controller.DeleteCharacter("0");
            Assert.IsFalse(context.Characters.Any(x => x.Name == "0"));
        }

        
        [TearDown]
        public void GlobalTeardown()
        {
            context.Database.EnsureDeleted();
        }


        [TestCase(5)]
        [TestCase(0)]
        public void GetAllCharactersTest(int length)
        {
            PopulateDataBase(length);
            Assert.AreEqual(length, controller.GetAllCharacters().Count);
        }

        [TestCase("test1")]
        public void GetCharacterByNameTest(string name)
        {
            PopulateDataBase();
            Character expected = new Character(name, new List<string>(new string[] { "One", "Two" }), "planet", new List<string>(new string[] { "LeftFriend", "RightFriend" }));
            context.Add(expected);
            context.SaveChanges();
            Character result = controller.GetCharacterByName(name);
            Assert.AreEqual(expected, result);
        }


        [TestCase("testName")]
        public void GetCharacterByNameTestWhereNoResults(string name)
        {
            PopulateDataBase();
            Character result = controller.GetCharacterByName(name);
            Assert.IsTrue(result == null);
        }

        [TestCase("testName")]
        public void CreateNewCharacterTest(string name)
        {
            Assert.IsTrue(context.Characters.Count(x => x.Name == name) == 0);
            controller.CreateNewCharacter(new Character(name, new List<string>(new string[] { "One", "Two" }), "planet", new List<string>(new string[] { "Left", "Right" })));
            Assert.IsTrue(context.Characters.Count(x => x.Name == name) == 1);
        }

        [Test()]
        public void UpdateCharacterTest()
        {
            PopulateDataBase();
            Character newCharacter = context.Characters.First(x => x.Name == "0");
            newCharacter.Planet = "planet destroyed";
            controller.UpdateCharacter("0", newCharacter);
            Assert.IsTrue(context.Characters.Count(x => x.Planet == "planet destroyed") == 1);
        }
    }
}
