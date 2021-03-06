using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class ActorViewModel
    {
        /// <summary>
        /// Gets or Sets the ActorId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ActorId alanưna veri girilmelidir.")]
        public int ActorId
        { get; set; }

        /// <summary>
        /// Gets or Sets the FirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName alanưna veri girilmelidir.")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName alanưna veri girilmelidir.")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanưna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}