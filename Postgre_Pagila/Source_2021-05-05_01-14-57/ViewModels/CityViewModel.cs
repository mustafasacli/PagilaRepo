using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class CityViewModel
    {
        /// <summary>
        /// Gets or Sets the CityId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CityId alanưna veri girilmelidir.")]
        public int CityId
        { get; set; }

        /// <summary>
        /// Gets or Sets the City
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City alanưna veri girilmelidir.")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or Sets the CountryId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CountryId alanưna veri girilmelidir.")]
        public int CountryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanưna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}