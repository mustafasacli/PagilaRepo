using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class CountryConfigurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.CountryId)

            builder.Property(e => e.CountryId)
                .HasColumnName("country_id")
                .HasColumnType("int4")
                .HasColumnOrder(1)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasColumnType("text")
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