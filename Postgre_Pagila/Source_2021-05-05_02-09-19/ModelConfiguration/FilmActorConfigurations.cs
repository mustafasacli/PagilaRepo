using System;
using System.Data.Entity.ModelConfiguration;

namespace Pagila.EntityConfiguration
{
    public class FilmActorConfigurations : EntityTypeConfiguration<FilmActor>
    {
        public FilmActorConfigurations()
        {
            this.HasKey(p => new { p.ActorId, p.FilmId })

            this.Property(e => e.ActorId)
            .HasColumnName("actor_id")
            .HasColumnType("int2")
            .HasColumnOrder(1)
            .IsRequired();

            this.Property(e => e.FilmId)
            .HasColumnName("film_id")
            .HasColumnType("int2")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.LastUpdate)
            .HasColumnName("last_update")
            .HasColumnType("timestamptz")
            .HasColumnOrder(3)
            .IsRequired();
        }
    }
}