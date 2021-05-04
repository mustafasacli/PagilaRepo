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
        [Required(AllowEmptyStrings = false, ErrorMessage = "StoreId alan�na veri girilmelidir.")]
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the ManagerStaffId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ManagerStaffId alan�na veri girilmelidir.")]
        public int ManagerStaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alan�na veri girilmelidir.")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alan�na veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}