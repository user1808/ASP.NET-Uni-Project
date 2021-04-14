using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CRUDProject.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        [MaxLength(40)]
        public string ArticleName { get; set; }
        [DataType(DataType.Currency)]
        public float ArticlePrice { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string ImageFilename { get; set; }
    }
}
