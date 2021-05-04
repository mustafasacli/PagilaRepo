using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class PaymentConfigurations : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(e => e.PaymentId)
                .HasColumnName("payment_id")
                .HasColumnType("int4")
                .HasColumnOrder(1)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.Property(e => e.CustomerId)
                .HasColumnName("customer_id")
                .HasColumnType("int2")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(e => e.StaffId)
                .HasColumnName("staff_id")
                .HasColumnType("int2")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(e => e.RentalId)
                .HasColumnName("rental_id")
                .HasColumnType("int4")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(e => e.Amount)
                .HasColumnName("amount")
                .HasColumnType("numeric")
                .HasColumnOrder(5)
                .IsRequired();

            builder.Property(e => e.PaymentDate)
                .HasColumnName("payment_date")
                .HasColumnType("timestamptz")
                .HasColumnOrder(6)
                .IsRequired();
        }
    }
}