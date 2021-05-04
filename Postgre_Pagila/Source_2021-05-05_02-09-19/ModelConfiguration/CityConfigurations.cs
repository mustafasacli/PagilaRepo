using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class CityConfigurations : EntityTypeConfiguration<City>
    {
        public CityConfigurations()
        {
            this.HasKey(p => p.CityId)

            this.Property(e => e.CityId)
            .HasColumnName("city_id")
            .HasColumnType("int4")
            .HasColumnOrder(1)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.City)
            .HasColumnName("city")
            .HasColumnType("text")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.CountryId)
            .HasColumnName("country_id")
            .HasColumnType("int2")
            .HasColumnOrder(3)
            .IsRequired();

            this.Property(e => e.LastUpdate)
            .HasColumnName("last_update")
            .HasColumnType("timestamptz")
            .HasColumnOrder(4)
            .IsRequired();
        }
    }
}