using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using StarWarsCharacterArchive.Controllers;
using StarWarsCharacterArchive.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsCharacterArchiveTests.Controllers
{
    [TestFixture()]
    public class CharacterControllerTests
    {

        [Test()]
        public void GetAllCharactersTest()
        {
            NullLogger<CharacterController> myLogger = new NullLogger<CharacterController>();
            CharacterController controller = new CharacterController(myLogger);
            IEnumerable<Character> result = controller.GetAllCharacters();
            Assert.AreEqual(2, result.Count());
        }
    }
}