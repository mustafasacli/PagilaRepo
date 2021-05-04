using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class StoreViewModel
    {
        /// <summary>
        /// Gets or Sets the StoreId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "StoreId alanýna veri girilmelidir.")]
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the ManagerStaffId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ManagerStaffId alanýna veri girilmelidir.")]
        public int ManagerStaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alanýna veri girilmelidir.")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}