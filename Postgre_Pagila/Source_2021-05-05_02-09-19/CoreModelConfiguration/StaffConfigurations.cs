using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class StaffConfigurations : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(e => e.StaffId)

            builder.Property(e => e.StaffId)
                .HasColumnName("staff_id")
                .HasColumnType("int4")
                .HasColumnOrder(1)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.Property(e => e.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("text")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasColumnName("last_name")
                .HasColumnType("text")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(e => e.AddressId)
                .HasColumnName("address_id")
                .HasColumnType("int2")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("text")
                .HasColumnOrder(5)
                .IsOptional();

            builder.Property(e => e.StoreId)
                .HasColumnName("store_id")
                .HasColumnType("int2")
                .HasColumnOrder(6)
                .IsRequired();

            builder.Property(e => e.Active)
                .HasColumnName("active")
                .HasColumnType("bool")
                .HasColumnOrder(7)
                .IsRequired();

            builder.Property(e => e.Username)
                .HasColumnName("username")
                .HasColumnType("text")
                .HasColumnOrder(8)
                .IsRequired();

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .HasColumnType("text")
                .HasColumnOrder(9)
                .IsOptional();

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("timestamptz")
                .HasColumnOrder(10)
                .IsRequired();

            builder.Property(e => e.Picture)
                .HasColumnName("picture")
                .HasColumnType("bytea")
                .HasColumnOrder(11)
                .IsOptional();
        }
    }
}