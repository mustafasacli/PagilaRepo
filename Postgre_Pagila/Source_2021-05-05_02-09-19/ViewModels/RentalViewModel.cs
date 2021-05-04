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
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalId alan�na veri girilmelidir.")]
        public int RentalId
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalDate alan�na veri girilmelidir.")]
        public DateTime RentalDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the InventoryId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "InventoryId alan�na veri girilmelidir.")]
        public int InventoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerId alan�na veri girilmelidir.")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "StaffId alan�na veri girilmelidir.")]
        public int StaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alan�na veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}