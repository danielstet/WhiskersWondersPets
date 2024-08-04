using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhiskersWondersPets.Models
{
    [Table("Animals")]
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string PictureName { get; set; } = "";
        public string Description { get; set; } = "";

        public int CategoryId { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        public virtual Category? Category { get; set; }
    }
}
