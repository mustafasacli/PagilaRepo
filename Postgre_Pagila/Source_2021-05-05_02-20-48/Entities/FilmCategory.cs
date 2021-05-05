using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("film_category", Schema = "public")]
    public class FilmCategoryEntity
    {
        /// <summary>
        /// Gets or Sets the FilmId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FilmId alanýna veri girilmelidir.")]
        [Column("film_id", Order = 1, TypeName = "int2")]
        public int FilmId
        { get; set; }

        /// <summary>
        /// Gets or Sets the CategoryId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CategoryId alanýna veri girilmelidir.")]
        [Column("category_id", Order = 2, TypeName = "int2")]
        public int CategoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        [Column("last_update", Order = 3, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        [ForeignKey("FilmId")]
        public virtual FilmEntity Film
        { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryEntity Category
        { get; set; }
    }
}