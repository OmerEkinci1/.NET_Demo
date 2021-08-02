using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public sealed class FirebirdDbContext : ProjectDbContext
    {
        public FirebirdDbContext(DbContextOptions<MsDbContext> options, IConfiguration configuration)
            : base(options, configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseFirebird(Configuration.GetConnectionString("DArchFirebirdContext")));
            }
        }
    }
}
