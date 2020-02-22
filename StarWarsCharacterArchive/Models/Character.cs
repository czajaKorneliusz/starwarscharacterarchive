using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarsCharacterArchive.Models
{

    public class Character
    {
        public string Name { get; set; }
        public List<Episode> Episodes { get; set; }
        public string Planet { get; set; }
        public List<Character> Friends { get; set; }

        public Character()
        {

        }

        public Character(string name, List<Episode> episodes, string planet, List<Character> friends)
        {
            Name = name;
            Episodes = episodes;
            Planet = planet;
            Friends = friends;
        }

        public enum Episode
        {
            [Display(Name = "New Hope")] NEW_HOPE = 4,
            [Display(Name = "Empire Strikes Back")] EMPIRE = 5,
            [Display(Name = "Return of the Jedi")] RETURN = 6
        }
    }


}
