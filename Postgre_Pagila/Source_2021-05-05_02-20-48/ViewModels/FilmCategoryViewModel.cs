using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class FilmCategoryViewModel
    {
        /// <summary>
        /// Gets or Sets the FilmId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FilmId alanýna veri girilmelidir.")]
        public int FilmId
        { get; set; }

        /// <summary>
        /// Gets or Sets the CategoryId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CategoryId alanýna veri girilmelidir.")]
        public int CategoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}