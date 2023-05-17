using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace easyPOS.Models
{
	public class Salesperson
	{
		[Key]
		public int UserId { get; set; }
		public string? Username { get; set; }
		public string? Password { get; set; }
		public string? Role { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Contact { get; set; }
	}
}