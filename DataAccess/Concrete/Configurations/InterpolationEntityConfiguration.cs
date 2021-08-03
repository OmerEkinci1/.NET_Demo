using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Configurations
{
    public class InterpolationEntityConfiguration : IEntityTypeConfiguration<Interpolation>
    {
        public void Configure(EntityTypeBuilder<Interpolation> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ImagePath).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ClassName).HasMaxLength(30).IsRequired(); // UI tarafına sığsın diye.
        }
    }
}
