using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("category", Schema = "public")]
    public class Category
    {
        /// <summary>
        /// Gets or Sets the CategoryId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CategoryId alanýna veri girilmelidir.")]
        [Column("category_id", Order = 1, TypeName = "int4")]
        public int CategoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name alanýna veri girilmelidir.")]
        [Column("name", Order = 2, TypeName = "text")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        [Column("last_update", Order = 3, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        public virtual ICollection<FilmCategory> FilmCategoryList
        { get; set; }
    }
}