using System;
using System.Data.Entity.ModelConfiguration;

namespace Pagila.EntityConfiguration
{
    public class FilmCategoryConfigurations : EntityTypeConfiguration<FilmCategory>
    {
        public FilmCategoryConfigurations()
        {
            this.HasKey(p => new { p.FilmId, p.CategoryId })

            this.Property(e => e.FilmId)
            .HasColumnName("film_id")
            .HasColumnType("int2")
            .HasColumnOrder(1)
            .IsRequired();

            this.Property(e => e.CategoryId)
            .HasColumnName("category_id")
            .HasColumnType("int2")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.LastUpdate)
            .HasColumnName("last_update")
            .HasColumnType("timestamptz")
            .HasColumnOrder(3)
            .IsRequired();
        }
    }
}