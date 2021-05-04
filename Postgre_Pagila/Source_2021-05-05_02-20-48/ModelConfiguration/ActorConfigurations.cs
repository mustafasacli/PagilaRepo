using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class ActorConfigurations : EntityTypeConfiguration<Actor>
    {
        public ActorConfigurations()
        {
            this.HasKey(p => p.ActorId)

            this.Property(e => e.ActorId)
            .HasColumnName("actor_id")
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

            this.Property(e => e.LastUpdate)
            .HasColumnName("last_update")
            .HasColumnType("timestamptz")
            .HasColumnOrder(4)
            .IsRequired();
        }
    }
}