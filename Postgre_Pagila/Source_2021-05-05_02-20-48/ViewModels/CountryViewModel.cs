using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class CountryViewModel
    {
        /// <summary>
        /// Gets or Sets the CountryId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CountryId alanưna veri girilmelidir.")]
        public int CountryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country alanưna veri girilmelidir.")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanưna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}