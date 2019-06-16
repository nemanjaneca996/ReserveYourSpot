using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class LocaleTypeConfiguration : IEntityTypeConfiguration<LocaleType>
    {
    
        public void Configure(EntityTypeBuilder<LocaleType> builder)
        {
            builder.Property(lt => lt.Name).IsRequired();
            builder.Property(lt => lt.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
