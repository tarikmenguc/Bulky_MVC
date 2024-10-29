using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public int DisplayOrder { get; set; }
        [Required]
        public  string Name { get; set; }
       
    }
}
