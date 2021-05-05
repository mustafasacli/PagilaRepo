using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("city", Schema = "public")]
    public class CityEntity
    {
        /// <summary>
        /// Gets or Sets the CityId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CityId alanýna veri girilmelidir.")]
        [Column("city_id", Order = 1, TypeName = "int4")]
        public int CityId
        { get; set; }

        /// <summary>
        /// Gets or Sets the City
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City alanýna veri girilmelidir.")]
        [Column("city", Order = 2, TypeName = "text")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or Sets the CountryId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CountryId alanýna veri girilmelidir.")]
        [Column("country_id", Order = 3, TypeName = "int2")]
        public int CountryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        [Column("last_update", Order = 4, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryEntity Country
        { get; set; }

        public virtual ICollection<AddressEntity> AddressList
        { get; set; }
    }
}