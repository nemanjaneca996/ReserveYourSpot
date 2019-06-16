using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {

        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Path).IsRequired();

            builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
