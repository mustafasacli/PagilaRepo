using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.EntityConfiguration
{
    public class LanguageConfigurations : EntityTypeConfiguration<Language>
    {
        public LanguageConfigurations()
        {
            this.HasKey(p => p.LanguageId)

            this.Property(e => e.LanguageId)
            .HasColumnName("language_id")
            .HasColumnType("int4")
            .HasColumnOrder(1)
            .IsRequired()
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.Name)
            .HasColumnName("name")
            .HasColumnType("bpchar")
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