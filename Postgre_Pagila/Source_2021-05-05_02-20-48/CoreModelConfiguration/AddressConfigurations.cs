using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => e.AddressId)

            builder.Property(e => e.AddressId)
                .HasColumnName("address_id")
                .HasColumnType("int4")
                .HasColumnOrder(1)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .HasColumnType("text")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(e => e.Address2)
                .HasColumnName("address2")
                .HasColumnType("text")
                .HasColumnOrder(3)
                .IsOptional();

            builder.Property(e => e.District)
                .HasColumnName("district")
                .HasColumnType("text")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(e => e.CityId)
                .HasColumnName("city_id")
                .HasColumnType("int2")
                .HasColumnOrder(5)
                .IsRequired();

            builder.Property(e => e.PostalCode)
                .HasColumnName("postal_code")
                .HasColumnType("text")
                .HasColumnOrder(6)
                .IsOptional();

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasColumnType("text")
                .HasColumnOrder(7)
                .IsRequired();

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("timestamptz")
                .HasColumnOrder(8)
                .IsRequired();
        }
    }
}