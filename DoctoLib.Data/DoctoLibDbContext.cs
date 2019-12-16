using DoctoLib.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctoLib.Data
{
	public class DoctoLibDbContext : DbContext
	{
		public DoctoLibDbContext(DbContextOptions<DoctoLibDbContext> options) 
			: base(options)
		{

		}
		public DbSet<Doctor> Doctors { get; set; }
	}
}
