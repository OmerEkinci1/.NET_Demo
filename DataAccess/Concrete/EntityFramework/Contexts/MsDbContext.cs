using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework
{
    public sealed class MsDbContext : ProjectDbContext
    {
        public MsDbContext(DbContextOptions<MsDbContext> options, IConfiguration configuration)
            : base(options, configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DArchMsContext")));
            }
        }
    }
}
