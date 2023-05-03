using Pagila.Command.Base;

namespace Pagila.Command.Film
{
    public class FilmInsertCommand : BaseInsertCommand
    {
        /// <summary>
        /// Gets or Sets the Title
        /// </summary>
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
        public int RentalDuration
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalRate
        /// </summary>
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
        public decimal ReplacementCost
        { get; set; }

        /// <summary>
        /// Gets or Sets the Rating
        /// </summary>
        public decimal? Rating
        { get; set; }

        /// <summary>
        /// Gets or Sets the SpecialFeatures
        /// </summary>
        public string SpecialFeatures
        { get; set; }

        /// <summary>
        /// Gets or Sets the Fulltext
        /// </summary>
        public string Fulltext
        { get; set; }
    }
}