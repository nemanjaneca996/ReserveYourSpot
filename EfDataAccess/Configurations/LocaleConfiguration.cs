using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class LocaleConfiguration : IEntityTypeConfiguration<Locale>
    {
        public void Configure(EntityTypeBuilder<Locale> builder)
        {
            builder.Property(l => l.Name).IsRequired();
            builder.Property(l => l.Password).IsRequired();
            builder.Property(l => l.EmailInfo).IsRequired();
            builder.Property(l => l.Address).IsRequired();
            builder.Property(l => l.Email).IsRequired();
            builder.Property(l => l.Mobile).IsRequired();

            builder.Property(l => l.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
