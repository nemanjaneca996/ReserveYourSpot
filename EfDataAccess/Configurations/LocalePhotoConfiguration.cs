using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class LocalePhotoConfiguration : IEntityTypeConfiguration<LocalePhoto>
    {
        public void Configure(EntityTypeBuilder<LocalePhoto> builder)
        {
            builder.Property(lp => lp.Name).IsRequired();
            builder.Property(lp => lp.Path).IsRequired();

            builder.Property(lp => lp.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
