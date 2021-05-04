using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pagila.EntityConfiguration
{
    public class FilmActorConfigurations : IEntityTypeConfiguration<FilmActor>
    {
        public void Configure(EntityTypeBuilder<FilmActor> builder)
        {
            this.HasKey(e => new { e.ActorId, e.FilmId })

            builder.Property(e => e.ActorId)
                .HasColumnName("actor_id")
                .HasColumnType("int2")
                .HasColumnOrder(1)
                .IsRequired();

            builder.Property(e => e.FilmId)
                .HasColumnName("film_id")
                .HasColumnType("int2")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("timestamptz")
                .HasColumnOrder(3)
                .IsRequired();
        }
    }
}