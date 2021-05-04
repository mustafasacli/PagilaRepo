using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class CityConfigurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(e => e.CityId)

            builder.Property(e => e.CityId)
                .HasColumnName("city_id")
                .HasColumnType("int4")
                .HasColumnOrder(1)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasColumnType("text")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(e => e.CountryId)
                .HasColumnName("country_id")
                .HasColumnType("int2")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("timestamptz")
                .HasColumnOrder(4)
                .IsRequired();
        }
    }
}