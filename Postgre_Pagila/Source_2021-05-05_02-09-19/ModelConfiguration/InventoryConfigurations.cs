using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class InventoryConfigurations : EntityTypeConfiguration<Inventory>
    {
        public InventoryConfigurations()
        {
            this.HasKey(p => p.InventoryId)

            this.Property(e => e.InventoryId)
            .HasColumnName("inventory_id")
            .HasColumnType("int4")
            .HasColumnOrder(1)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.FilmId)
            .HasColumnName("film_id")
            .HasColumnType("int2")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.StoreId)
            .HasColumnName("store_id")
            .HasColumnType("int2")
            .HasColumnOrder(3)
            .IsRequired();

            this.Property(e => e.LastUpdate)
            .HasColumnName("last_update")
            .HasColumnType("timestamptz")
            .HasColumnOrder(4)
            .IsRequired();
        }
    }
}