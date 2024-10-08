﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhiskersWondersPets.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; } = "";
        public virtual ICollection<Animal>? Animals { get; set; }
    }
}
