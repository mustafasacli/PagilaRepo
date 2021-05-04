using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class PaymentConfigurations : EntityTypeConfiguration<Payment>
    {
        public PaymentConfigurations()
        {
            this.Property(e => e.PaymentId)
            .HasColumnName("payment_id")
            .HasColumnType("int4")
            .HasColumnOrder(1)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.CustomerId)
            .HasColumnName("customer_id")
            .HasColumnType("int2")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.StaffId)
            .HasColumnName("staff_id")
            .HasColumnType("int2")
            .HasColumnOrder(3)
            .IsRequired();

            this.Property(e => e.RentalId)
            .HasColumnName("rental_id")
            .HasColumnType("int4")
            .HasColumnOrder(4)
            .IsRequired();

            this.Property(e => e.Amount)
            .HasColumnName("amount")
            .HasColumnType("numeric")
            .HasColumnOrder(5)
            .IsRequired();

            this.Property(e => e.PaymentDate)
            .HasColumnName("payment_date")
            .HasColumnType("timestamptz")
            .HasColumnOrder(6)
            .IsRequired();
        }
    }
}