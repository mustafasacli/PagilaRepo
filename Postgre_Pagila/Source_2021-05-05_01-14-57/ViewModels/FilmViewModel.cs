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
        [Required(AllowEmptyStrings = false, ErrorMessage = "FilmId alanưna veri girilmelidir.")]
        public int FilmId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Title
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title alanưna veri girilmelidir.")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "LanguageId alanưna veri girilmelidir.")]
        public int LanguageId
        { get; set; }

        /// <summary>
        /// Gets or Sets the OriginalLanguageId
        /// </summary>
        public int? OriginalLanguageId
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalDuration
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalDuration alanưna veri girilmelidir.")]
        public int RentalDuration
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalRate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalRate alanưna veri girilmelidir.")]
        public  RentalRate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Length
        /// </summary>
        public int? Length
        { get; set; }

        /// <summary>
        /// Gets or Sets the ReplacementCost
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ReplacementCost alanưna veri girilmelidir.")]
        public  ReplacementCost
        { get; set; }

        /// <summary>
        /// Gets or Sets the Rating
        /// </summary>
        public ? Rating
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanưna veri girilmelidir.")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fulltext alanưna veri girilmelidir.")]
        public  Fulltext
        { get; set; }
    }
}