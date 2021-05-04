using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class CategoryViewModel
    {
        /// <summary>
        /// Gets or Sets the CategoryId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CategoryId alanýna veri girilmelidir.")]
        public int CategoryId
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