using System;
using Microsoft.EntityFrameworkCore;

namespace easyPOS.Models
{
	public class easyPOSDbContext : DbContext
	{
		public easyPOSDbContext(DbContextOptions<easyPOSDbContext> options) : base(options)
		{

		}

		public DbSet<Salesperson> Salespeoples { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}

