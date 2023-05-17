using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace easyPOS.Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
		public string? ProductName { get; set; }
		public string? Description { get; set; }
		[Precision(6, 2)]
		public decimal Price { get; set; }
		public string? Category { get; set; }
		public int Quantity { get; set; }
	}
}

