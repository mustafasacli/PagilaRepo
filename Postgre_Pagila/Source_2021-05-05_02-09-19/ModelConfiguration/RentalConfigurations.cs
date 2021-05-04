using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class RentalConfigurations : EntityTypeConfiguration<Rental>
    {
        public RentalConfigurations()
        {
            this.HasKey(p => p.RentalId)

            this.Property(e => e.RentalId)
            .HasColumnName("rental_id")
            .HasColumnType("int4")
            .HasColumnOrder(1)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.RentalDate)
            .HasColumnName("rental_date")
            .HasColumnType("timestamptz")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.InventoryId)
            .HasColumnName("inventory_id")
            .HasColumnType("int4")
            .HasColumnOrder(3)
            .IsRequired();

            this.Property(e => e.CustomerId)
            .HasColumnName("customer_id")
            .HasColumnType("int2")
            .HasColumnOrder(4)
            .IsRequired();

            this.Property(e => e.ReturnDate)
            .HasColumnName("return_date")
            .HasColumnType("timestamptz")
            .HasColumnOrder(5)
            .IsOptional();

            this.Property(e => e.StaffId)
            .HasColumnName("staff_id")
            .HasColumnType("int2")
            .HasColumnOrder(6)
            .IsRequired();

            this.Property(e => e.LastUpdate)
            .HasColumnName("last_update")
            .HasColumnType("timestamptz")
            .HasColumnOrder(7)
            .IsRequired();
        }
    }
}