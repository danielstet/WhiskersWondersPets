using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhiskersWondersPets.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        
        public int AnimalId { get; set; }

        public string UserComment { get; set; } = "";

        public virtual Animal? Animal { get; set; }

    }
}
