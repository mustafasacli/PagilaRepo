using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("film", Schema = "public")]
    public class FilmEntity
    {
        /// <summary>
        /// Gets or Sets the FilmId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FilmId alanưna veri girilmelidir.")]
        [Column("film_id", Order = 1, TypeName = "int4")]
        public int FilmId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Title
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title alanưna veri girilmelidir.")]
        [Column("title", Order = 2, TypeName = "text")]
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or Sets the Description
        /// </summary>
        [Column("description", Order = 3, TypeName = "text")]
        public string Description
        { get; set; }

        /// <summary>
        /// Gets or Sets the ReleaseYear
        /// </summary>
        [Column("release_year", Order = 4, TypeName = "int4")]
        public int? ReleaseYear
        { get; set; }

        /// <summary>
        /// Gets or Sets the LanguageId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LanguageId alanưna veri girilmelidir.")]
        [Column("language_id", Order = 5, TypeName = "int2")]
        public short LanguageId
        { get; set; }

        /// <summary>
        /// Gets or Sets the OriginalLanguageId
        /// </summary>
        [Column("original_language_id", Order = 6, TypeName = "int2")]
        public short? OriginalLanguageId
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalDuration
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalDuration alanưna veri girilmelidir.")]
        [Column("rental_duration", Order = 7, TypeName = "int2")]
        public int RentalDuration
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalRate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalRate alanưna veri girilmelidir.")]
        [Column("rental_rate", Order = 8, TypeName = "numeric")]
        public decimal RentalRate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Length
        /// </summary>
        [Column("length", Order = 9, TypeName = "int2")]
        public short? Length
        { get; set; }

        /// <summary>
        /// Gets or Sets the ReplacementCost
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ReplacementCost alanưna veri girilmelidir.")]
        [Column("replacement_cost", Order = 10, TypeName = "numeric")]
        public decimal ReplacementCost
        { get; set; }

        /// <summary>
        /// Gets or Sets the Rating
        /// </summary>
        [Column("rating", Order = 11, TypeName = "mpaa_rating")]
        public decimal? Rating
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanưna veri girilmelidir.")]
        [Column("last_update", Order = 12, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        /// <summary>
        /// Gets or Sets the SpecialFeatures
        /// </summary>
        [Column("special_features", Order = 13, TypeName = "_text")]
        public string SpecialFeatures
        { get; set; }

        /// <summary>
        /// Gets or Sets the Fulltext
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fulltext alanưna veri girilmelidir.")]
        [Column("fulltext", Order = 14, TypeName = "tsvector")]
        public string Fulltext
        { get; set; }

        [ForeignKey("OriginalLanguageId")]
        public virtual LanguageEntity Language_OriginalLanguageId
        { get; set; }

        [ForeignKey("LanguageId")]
        public virtual LanguageEntity Language_LanguageId
        { get; set; }

        public virtual ICollection<FilmActorEntity> FilmActorList
        { get; set; }

        public virtual ICollection<FilmCategoryEntity> FilmCategoryList
        { get; set; }

        public virtual ICollection<InventoryEntity> InventoryList
        { get; set; }

        [NotMapped]
        public string LanguageName
        { get; set; }

        [NotMapped]
        public string OriginalLanguageName
        { get; set; }
    }
}