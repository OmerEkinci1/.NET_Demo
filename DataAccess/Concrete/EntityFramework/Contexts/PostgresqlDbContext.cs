using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
	public class PostgresqlDbContext : DbContext
	{
		public PostgresqlDbContext(DbContextOptions<PostgresqlDbContext> options, IConfiguration configuration)
																				: base(options)
		{
			Configuration = configuration;
		}

		protected PostgresqlDbContext(DbContextOptions options, IConfiguration configuration)
																		: base(options)
		{
			Configuration = configuration;
		}

        public DbSet<Interpolation> Interpolations { get; set; }

		protected IConfiguration Configuration { get; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				base.OnConfiguring(optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DArchPgContext")).EnableSensitiveDataLogging());

			}
		}

	}
}
