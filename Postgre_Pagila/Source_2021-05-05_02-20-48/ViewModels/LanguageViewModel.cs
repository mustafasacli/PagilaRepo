using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class LanguageViewModel
    {
        /// <summary>
        /// Gets or Sets the LanguageId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "LanguageId alanýna veri girilmelidir.")]
        public int LanguageId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name alanýna veri girilmelidir.")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}