using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class CountryConfigurations : EntityTypeConfiguration<Country>
    {
        public CountryConfigurations()
        {
            this.HasKey(p => p.CountryId)

            this.Property(e => e.CountryId)
            .HasColumnName("country_id")
            .HasColumnType("int4")
            .HasColumnOrder(1)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.Country)
            .HasColumnName("country")
            .HasColumnType("text")
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