using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsCharacterArchive.Models;
using System.Collections.Generic;
using static StarWarsCharacterArchive.Models.Character;

namespace StarWarsCharacterArchive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;

        public CharacterController(ILogger<CharacterController> logger)
        {
            _logger = logger;
        }




        [HttpGet]
        public List<Character> GetAllCharacters()
        {
            List<Character> characterList = new List<Character>
            {
                new Character("Luke", new List<Episode>(new Episode[] { (Episode)4, (Episode)5, (Episode)6 }), null, null),
                new Character("Leia", new List<Episode>(new Episode[] { (Episode)4, (Episode)5, (Episode)6 }), "Alderaan", null)
            };
            return characterList;

        }



    }
}
