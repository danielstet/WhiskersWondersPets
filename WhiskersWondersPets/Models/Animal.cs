using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace WhiskersWondersPets.Models
{
    [Table("Animals")]
    public class Animal
    {
        [Required]
        public int AnimalId { get; set; }
        [Required]
        [RegexStringValidator("^[a-zA-Z]+$")]
        public string? Name { get; set; }
        [Required]
        [Range(0, 15000)]
        public int Age { get; set; }
        [Required]
        public string PictureName { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public int CategoryId { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        public virtual Category? Category { get; set; }
    }
}
