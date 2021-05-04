using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class StaffConfigurations : EntityTypeConfiguration<Staff>
    {
        public StaffConfigurations()
        {
            this.HasKey(p => p.StaffId)

            this.Property(e => e.StaffId)
            .HasColumnName("staff_id")
            .HasColumnType("int4")
            .HasColumnOrder(1)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.FirstName)
            .HasColumnName("first_name")
            .HasColumnType("text")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.LastName)
            .HasColumnName("last_name")
            .HasColumnType("text")
            .HasColumnOrder(3)
            .IsRequired();

            this.Property(e => e.AddressId)
            .HasColumnName("address_id")
            .HasColumnType("int2")
            .HasColumnOrder(4)
            .IsRequired();

            this.Property(e => e.Email)
            .HasColumnName("email")
            .HasColumnType("text")
            .HasColumnOrder(5)
            .IsOptional();

            this.Property(e => e.StoreId)
            .HasColumnName("store_id")
            .HasColumnType("int2")
            .HasColumnOrder(6)
            .IsRequired();

            this.Property(e => e.Active)
            .HasColumnName("active")
            .HasColumnType("bool")
            .HasColumnOrder(7)
            .IsRequired();

            this.Property(e => e.Username)
            .HasColumnName("username")
            .HasColumnType("text")
            .HasColumnOrder(8)
            .IsRequired();

            this.Property(e => e.Password)
            .HasColumnName("password")
            .HasColumnType("text")
            .HasColumnOrder(9)
            .IsOptional();

            this.Property(e => e.LastUpdate)
            .HasColumnName("last_update")
            .HasColumnType("timestamptz")
            .HasColumnOrder(10)
            .IsRequired();

            this.Property(e => e.Picture)
            .HasColumnName("picture")
            .HasColumnType("bytea")
            .HasColumnOrder(11)
            .IsOptional();
        }
    }
}