 
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
	public class Product
	{
		[Key]
		public int ProductUniqueId { get; set; }
        [Required]
        public int ProductId { get; set; }
		[Required]
		[StringLength(300)]
		public string? ProductName { get; set; }
		[Required]
		public int Price { get; set; }
        [Required]
        [StringLength(200)]
        public string? Manufacturer { get; set; }
	}
}

