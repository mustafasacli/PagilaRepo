using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("country", Schema = "public")]
    public class CountryEntity
    {
        /// <summary>
        /// Gets or Sets the CountryId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CountryId alanýna veri girilmelidir.")]
        [Column("country_id", Order = 1, TypeName = "int4")]
        public int CountryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country alanýna veri girilmelidir.")]
        [Column("country", Order = 2, TypeName = "text")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        [Column("last_update", Order = 3, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        public virtual ICollection<CityEntity> CityList
        { get; set; }
    }
}