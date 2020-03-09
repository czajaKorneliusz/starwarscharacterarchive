using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StarWarsCharacterArchive.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsCharacterArchive.Controllers
{
    [ApiController]
    [Route("StarWarsCharacterArchive/[controller]")]
    [Produces("application/json")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;

        public CharacterController(ILogger<CharacterController> logger, CharacterContext context)
        {
            _logger = logger;
            _context = context;
        }


        private readonly CharacterContext _context;

        [HttpGet]
        public List<Character> GetAllCharacters()
        {
            return _context.Characters.ToList();
        }


        [HttpGet("{name}")]
        public Character GetCharacterByName(string name)
        {
            return _context.Characters.FirstOrDefault(x => x.Name == name);
        }


        [HttpPost]
        public IActionResult CreateNewCharacter(Character character)
        {
            try
            {
                _context.Add(character);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
                
            }
            return Created(character.Name, new { name = character.Name });
        }

        [HttpPut("{name}")]
        public IActionResult UpdateCharacter(string name, Character character)
        {
            if (name != character.Name)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CharacterTableExists(name))
                {
                    return NotFound();
                }
                else
                {
                    throw new UserFriendlyException($"error: concurrent update {character.Name}", ex);
                }
            }
            return NoContent();
        }


        [HttpDelete("{name}")]
        public ActionResult<Character> DeleteCharacter(string name)
        {
            Character character = _context.Characters.Find(name);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            _context.SaveChanges();

            return character;
        }


        private bool CharacterTableExists(string name)
        {
            return _context.Characters.Any(e => e.Name == name);
        }
    }
}
