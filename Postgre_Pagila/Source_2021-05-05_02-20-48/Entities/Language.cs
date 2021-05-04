using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("language", Schema = "public")]
    public class Language
    {
        /// <summary>
        /// Gets or Sets the LanguageId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "LanguageId alanýna veri girilmelidir.")]
        [Column("language_id", Order = 1, TypeName = "int4")]
        public int LanguageId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name alanýna veri girilmelidir.")]
        [Column("name", Order = 2, TypeName = "bpchar")]
        public char Name
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        [Column("last_update", Order = 3, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        public virtual ICollection<Film> FilmList
        { get; set; }
    }
}