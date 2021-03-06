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
        [Required(AllowEmptyStrings = false, ErrorMessage = "StoreId alanưna veri girilmelidir.")]
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the ManagerStaffId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ManagerStaffId alanưna veri girilmelidir.")]
        public int ManagerStaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alanưna veri girilmelidir.")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanưna veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}