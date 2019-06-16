using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class ReviewPhotoConfiguration : IEntityTypeConfiguration<ReviewPhoto>
    {

        public void Configure(EntityTypeBuilder<ReviewPhoto> builder)
        {
            builder.Property(rp => rp.Name).IsRequired();
            builder.Property(rp => rp.Path).IsRequired();

            builder.Property(rp => rp.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
