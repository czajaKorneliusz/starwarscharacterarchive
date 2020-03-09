using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        [JsonProperty(Order = 1)]
        public virtual IEnumerable<Friend> Friends { get; set; }

        public Character()
        {

        }

        public Character(string name, IEnumerable<string> episodes, string planet, IEnumerable<Friend> friends)
        {
            Name = name;
            Episodes = episodes;
            Planet = planet;
            Friends = friends;
        }
    }

}
