using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class FilmViewModel
    {
        /// <summary>
        /// Gets or Sets the FilmId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FilmId alanýna veri girilmelidir.")]
        public int FilmId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Title
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title alanýna veri girilmelidir.")]
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or Sets the Description
        /// </summary>
        public string Description
        { get; set; }

        /// <summary>
        /// Gets or Sets the ReleaseYear
        /// </summary>
        public int? ReleaseYear
        { get; set; }

        /// <summary>
        /// Gets or Sets the LanguageId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LanguageId alanýna veri girilmelidir.")]
        public short LanguageId
        { get; set; }

        /// <summary>
        /// Gets or Sets the OriginalLanguageId
        /// </summary>
        public short? OriginalLanguageId
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalDuration
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalDuration alanýna veri girilmelidir.")]
        public int RentalDuration
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalRate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalRate alanýna veri girilmelidir.")]
        public decimal RentalRate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Length
        /// </summary>
        public short? Length
        { get; set; }

        /// <summary>
        /// Gets or Sets the ReplacementCost
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ReplacementCost alanýna veri girilmelidir.")]
        public decimal ReplacementCost
        { get; set; }

        /// <summary>
        /// Gets or Sets the Rating
        /// </summary>
        public decimal? Rating
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }

        /// <summary>
        /// Gets or Sets the SpecialFeatures
        /// </summary>
        public string SpecialFeatures
        { get; set; }

        /// <summary>
        /// Gets or Sets the Fulltext
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fulltext alanýna veri girilmelidir.")]
        public string Fulltext
        { get; set; }

        public string LanguageName
        { get; set; }

        public string OriginalLanguageName
        { get; set; }
    }
}