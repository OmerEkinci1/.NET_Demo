using Microsoft.Extensions.Configuration;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Fakes.DArch
{
	public sealed class DArchInMemory : PostgresqlDbContext
	{
		public DArchInMemory(DbContextOptions<DArchInMemory> options, IConfiguration configuration)
			: base(options, configuration)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				base.OnConfiguring(optionsBuilder.UseInMemoryDatabase(Configuration.GetConnectionString("DArchInMemory")));

			}
		}

	}
}
