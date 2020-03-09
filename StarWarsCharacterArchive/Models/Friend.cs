using System.ComponentModel.DataAnnotations;

namespace StarWarsCharacterArchive.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Character Character { get; set; }
    }
}
