using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class LocaleTableConfiguration : IEntityTypeConfiguration<LocaleTable>
    {
        public void Configure(EntityTypeBuilder<LocaleTable> builder)
        {
            builder.Property(lt => lt.Name).IsRequired();
        }
    }
}
