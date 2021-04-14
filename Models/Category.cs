using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUDProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(40)]
        public string CategoryName { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
