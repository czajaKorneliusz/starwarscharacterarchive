using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsCharacterArchive.Models
{
    [Table("Character")]
    public class Character
    {
        [Key]
        [Required]
        public string Name { get; set; }
        public IEnumerable<string> Episodes { get; set; }
        public string Planet { get; set; }
        public IEnumerable<string> Friends { get; set; }


        public ICollection<Friend> FriendList { get; set; }

        public Character()
        {

        }

        public Character(string name, IEnumerable<string> episodes, string planet, IEnumerable<string> friends)
        {
            Name = name;
            Episodes = episodes;
            Planet = planet;
            Friends = friends;
        }
    }

}
