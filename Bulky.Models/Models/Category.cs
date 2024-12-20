﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be 1-100")]
        public int DisplayOrder { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30,ErrorMessage ="Name lenght must be 1-30")]
        public  string Name { get; set; }
       
    }
}
