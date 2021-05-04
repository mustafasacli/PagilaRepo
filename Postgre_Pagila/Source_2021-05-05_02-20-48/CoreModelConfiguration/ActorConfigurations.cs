using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class ActorConfigurations : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(e => e.ActorId)

            builder.Property(e => e.ActorId)
                .HasColumnName("actor_id")
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

            builder.Property(e => e.LastUpdate)
                .HasColumnName("last_update")
                .HasColumnType("timestamptz")
                .HasColumnOrder(4)
                .IsRequired();
        }
    }
}