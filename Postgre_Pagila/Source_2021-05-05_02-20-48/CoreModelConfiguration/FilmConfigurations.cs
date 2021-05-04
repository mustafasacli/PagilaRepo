using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class FilmConfigurations : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(e => e.FilmId)

            builder.Property(e => e.FilmId)
                .HasColumnName("film_id")
                .HasColumnType("int4")
                .HasColumnOrder(1)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("text")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .HasColumnOrder(3)
                .IsOptional();

            builder.Property(e => e.ReleaseYear)
                .HasColumnName("release_year")
                .HasColumnType("int4")
                .HasColumnOrder(4)
                .IsOptional();

            builder.Property(e => e.LanguageId)
                .HasColumnName("language_id")
                .HasColumnType("int2")
                .HasColumnOrder(5)
                .IsRequired();

            builder.Property(e => e.OriginalLanguageId)
                .HasColumnName("original_language_id")
                .HasColumnType("int2")
                .HasColumnOrder(6)
                .IsOptional();

            builder.Property(e => e.RentalDuration)
                .HasColumnName("rental_duration")
                .HasColumnType("int2")
                .HasColumnOrder(7)
                .IsRequired();

            builder.Property(e => e.RentalRate)
                .HasColumnName("rental_rate")
                .HasColumnType("numeric")
                .HasColumnOrder(8)
                .IsRequired();

            builder.Property(e => e.Length)
                .HasColumnName("length")
                .HasColumnType("int2")
                .HasColumnOrder(9)
                .IsOptional();

            builder.Property(e => e.ReplacementCost)
                .HasColumnName("replacement_cost")
                .HasColumnType("numeric")
                .HasColumnOrder(10)
                .IsRequired();

            builder.Property(e => e.Rating)
                .HasColumnName("rating")
                .HasColumnType("mpaa_rating")
                .HasColumnOrder(11)
                .IsOptional();

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("timestamptz")
                .HasColumnOrder(12)
                .IsRequired();

            builder.Property(e => e.SpecialFeatures)
                .HasColumnName("special_features")
                .HasColumnType("_text")
                .HasColumnOrder(13)
                .IsOptional();

            builder.Property(e => e.Fulltext)
                .HasColumnName("fulltext")
                .HasColumnType("tsvector")
                .HasColumnOrder(14)
                .IsRequired();
        }
    }
}