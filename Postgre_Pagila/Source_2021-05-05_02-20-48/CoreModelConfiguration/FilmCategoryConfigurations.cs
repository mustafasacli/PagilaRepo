using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pagila.EntityConfiguration
{
    public class FilmCategoryConfigurations : IEntityTypeConfiguration<FilmCategory>
    {
        public void Configure(EntityTypeBuilder<FilmCategory> builder)
        {
            this.HasKey(e => new { e.FilmId, e.CategoryId })

            builder.Property(e => e.FilmId)
                .HasColumnName("film_id")
                .HasColumnType("int2")
                .HasColumnOrder(1)
                .IsRequired();

            builder.Property(e => e.CategoryId)
                .HasColumnName("category_id")
                .HasColumnType("int2")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("timestamptz")
                .HasColumnOrder(3)
                .IsRequired();
        }
    }
}