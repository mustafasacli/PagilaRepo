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
        [Required(AllowEmptyStrings = false, ErrorMessage = "CountryId alanýna veri girilmelidir.")]
        public int CountryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country alanýna veri girilmelidir.")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}