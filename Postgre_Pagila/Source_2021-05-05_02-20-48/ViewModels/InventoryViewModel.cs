using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class InventoryViewModel
    {
        /// <summary>
        /// Gets or Sets the InventoryId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "InventoryId alanưna veri girilmelidir.")]
        public int InventoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the FilmId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FilmId alanưna veri girilmelidir.")]
        public int FilmId
        { get; set; }

        /// <summary>
        /// Gets or Sets the StoreId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StoreId alanưna veri girilmelidir.")]
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanưna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}