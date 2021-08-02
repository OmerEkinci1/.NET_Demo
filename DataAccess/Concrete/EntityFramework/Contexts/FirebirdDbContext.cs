using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class MsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseFirebird(@"D:\Program Files\Firebird\Firebird_4_0\agteks_demo.fdb");

        }

        public DbSet<Interpolation> Interpolations { get; set; }
    }
}
