using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class RentalConfigurations : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(e => e.RentalId)

            builder.Property(e => e.RentalId)
                .HasColumnName("rental_id")
                .HasColumnType("int4")
                .HasColumnOrder(1)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.Property(e => e.RentalDate)
                .HasColumnName("rental_date")
                .HasColumnType("timestamptz")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(e => e.InventoryId)
                .HasColumnName("inventory_id")
                .HasColumnType("int4")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(e => e.CustomerId)
                .HasColumnName("customer_id")
                .HasColumnType("int2")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(e => e.ReturnDate)
                .HasColumnName("return_date")
                .HasColumnType("timestamptz")
                .HasColumnOrder(5)
                .IsOptional();

            builder.Property(e => e.StaffId)
                .HasColumnName("staff_id")
                .HasColumnType("int2")
                .HasColumnOrder(6)
                .IsRequired();

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("timestamptz")
                .HasColumnOrder(7)
                .IsRequired();
        }
    }
}