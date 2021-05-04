using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class StoreConfigurations : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(e => e.StoreId)

            builder.Property(e => e.StoreId)
                .HasColumnName("store_id")
                .HasColumnType("int4")
                .HasColumnOrder(1)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.Property(e => e.ManagerStaffId)
                .HasColumnName("manager_staff_id")
                .HasColumnType("int2")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(e => e.AddressId)
                .HasColumnName("address_id")
                .HasColumnType("int2")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("timestamptz")
                .HasColumnOrder(4)
                .IsRequired();
        }
    }
}