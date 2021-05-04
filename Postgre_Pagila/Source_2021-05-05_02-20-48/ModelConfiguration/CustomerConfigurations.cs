using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            this.HasKey(p => p.CustomerId)

            this.Property(e => e.CustomerId)
            .HasColumnName("customer_id")
            .HasColumnType("int4")
            .HasColumnOrder(1)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.StoreId)
            .HasColumnName("store_id")
            .HasColumnType("int2")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.FirstName)
            .HasColumnName("first_name")
            .HasColumnType("text")
            .HasColumnOrder(3)
            .IsRequired();

            this.Property(e => e.LastName)
            .HasColumnName("last_name")
            .HasColumnType("text")
            .HasColumnOrder(4)
            .IsRequired();

            this.Property(e => e.Email)
            .HasColumnName("email")
            .HasColumnType("text")
            .HasColumnOrder(5)
            .IsOptional();

            this.Property(e => e.AddressId)
            .HasColumnName("address_id")
            .HasColumnType("int2")
            .HasColumnOrder(6)
            .IsRequired();

            this.Property(e => e.Activebool)
            .HasColumnName("activebool")
            .HasColumnType("bool")
            .HasColumnOrder(7)
            .IsRequired();

            this.Property(e => e.CreateDate)
            .HasColumnName("create_date")
            .HasColumnType("date")
            .HasColumnOrder(8)
            .IsRequired();

            this.Property(e => e.LastUpdate)
            .HasColumnName("last_update")
            .HasColumnType("timestamptz")
            .HasColumnOrder(9)
            .IsOptional();

            this.Property(e => e.Active)
            .HasColumnName("active")
            .HasColumnType("int4")
            .HasColumnOrder(10)
            .IsOptional();
        }
    }
}