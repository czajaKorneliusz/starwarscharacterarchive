using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace StarWarsCharacterArchive.Models
{
    public class Friend
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Character Character { get; set; }
    }
}
