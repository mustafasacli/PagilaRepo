using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class FilmActorViewModel
    {
        /// <summary>
        /// Gets or Sets the ActorId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ActorId alanưna veri girilmelidir.")]
        public int ActorId
        { get; set; }

        /// <summary>
        /// Gets or Sets the FilmId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FilmId alanưna veri girilmelidir.")]
        public int FilmId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanưna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}