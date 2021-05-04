using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class RentalViewModel
    {
        /// <summary>
        /// Gets or Sets the RentalId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalId alanýna veri girilmelidir.")]
        public int RentalId
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalDate alanýna veri girilmelidir.")]
        public DateTime RentalDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the InventoryId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "InventoryId alanýna veri girilmelidir.")]
        public int InventoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerId alanýna veri girilmelidir.")]
        public int CustomerId
        { get; set; }

        /// <summary>
        /// Gets or Sets the ReturnDate
        /// </summary>
        public DateTime? ReturnDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the StaffId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StaffId alanýna veri girilmelidir.")]
        public int StaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}