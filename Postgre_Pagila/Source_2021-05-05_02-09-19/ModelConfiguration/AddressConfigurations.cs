using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class AddressConfigurations : EntityTypeConfiguration<Address>
    {
        public AddressConfigurations()
        {
            this.HasKey(p => p.AddressId)

            this.Property(e => e.AddressId)
            .HasColumnName("address_id")
            .HasColumnType("int4")
            .HasColumnOrder(1)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.Address)
            .HasColumnName("address")
            .HasColumnType("text")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.Address2)
            .HasColumnName("address2")
            .HasColumnType("text")
            .HasColumnOrder(3)
            .IsOptional();

            this.Property(e => e.District)
            .HasColumnName("district")
            .HasColumnType("text")
            .HasColumnOrder(4)
            .IsRequired();

            this.Property(e => e.CityId)
            .HasColumnName("city_id")
            .HasColumnType("int2")
            .HasColumnOrder(5)
            .IsRequired();

            this.Property(e => e.PostalCode)
            .HasColumnName("postal_code")
            .HasColumnType("text")
            .HasColumnOrder(6)
            .IsOptional();

            this.Property(e => e.Phone)
            .HasColumnName("phone")
            .HasColumnType("text")
            .HasColumnOrder(7)
            .IsRequired();

            this.Property(e => e.LastUpdate)
            .HasColumnName("last_update")
            .HasColumnType("timestamptz")
            .HasColumnOrder(8)
            .IsRequired();
        }
    }
}