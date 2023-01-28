using System.ComponentModel.DataAnnotations;

namespace CategoryService.Models
{
    public class Category
    {
        [Key]
        public int CategoryUniqueueId { get; set; }
        [Required]
        [StringLength(100)]
        public string? CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string? CategoryName { get; set; }
    }
}
