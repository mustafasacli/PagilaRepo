using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class FilmConfigurations : EntityTypeConfiguration<Film>
    {
        public FilmConfigurations()
        {
            this.HasKey(p => p.FilmId)

            this.Property(e => e.FilmId)
            .HasColumnName("film_id")
            .HasColumnType("int4")
            .HasColumnOrder(1)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.Title)
            .HasColumnName("title")
            .HasColumnType("text")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .HasColumnOrder(3)
            .IsOptional();

            this.Property(e => e.ReleaseYear)
            .HasColumnName("release_year")
            .HasColumnType("int4")
            .HasColumnOrder(4)
            .IsOptional();

            this.Property(e => e.LanguageId)
            .HasColumnName("language_id")
            .HasColumnType("int2")
            .HasColumnOrder(5)
            .IsRequired();

            this.Property(e => e.OriginalLanguageId)
            .HasColumnName("original_language_id")
            .HasColumnType("int2")
            .HasColumnOrder(6)
            .IsOptional();

            this.Property(e => e.RentalDuration)
            .HasColumnName("rental_duration")
            .HasColumnType("int2")
            .HasColumnOrder(7)
            .IsRequired();

            this.Property(e => e.RentalRate)
            .HasColumnName("rental_rate")
            .HasColumnType("numeric")
            .HasColumnOrder(8)
            .IsRequired();

            this.Property(e => e.Length)
            .HasColumnName("length")
            .HasColumnType("int2")
            .HasColumnOrder(9)
            .IsOptional();

            this.Property(e => e.ReplacementCost)
            .HasColumnName("replacement_cost")
            .HasColumnType("numeric")
            .HasColumnOrder(10)
            .IsRequired();

            this.Property(e => e.Rating)
            .HasColumnName("rating")
            .HasColumnType("mpaa_rating")
            .HasColumnOrder(11)
            .IsOptional();

            this.Property(e => e.LastUpdate)
            .HasColumnName("last_update")
            .HasColumnType("timestamptz")
            .HasColumnOrder(12)
            .IsRequired();

            this.Property(e => e.SpecialFeatures)
            .HasColumnName("special_features")
            .HasColumnType("_text")
            .HasColumnOrder(13)
            .IsOptional();

            this.Property(e => e.Fulltext)
            .HasColumnName("fulltext")
            .HasColumnType("tsvector")
            .HasColumnOrder(14)
            .IsRequired();
        }
    }
}