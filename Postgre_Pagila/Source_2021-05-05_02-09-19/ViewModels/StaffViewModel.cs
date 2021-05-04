using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class StaffViewModel
    {
        /// <summary>
        /// Gets or Sets the StaffId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "StaffId alan�na veri girilmelidir.")]
        public int StaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the FirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName alan�na veri girilmelidir.")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName alan�na veri girilmelidir.")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alan�na veri girilmelidir.")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Email
        /// </summary>
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or Sets the StoreId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StoreId alan�na veri girilmelidir.")]
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Active
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Active alan�na veri girilmelidir.")]
        public bool Active
        { get; set; }

        /// <summary>
        /// Gets or Sets the Username
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username alan�na veri girilmelidir.")]
        public string Username
        { get; set; }

        /// <summary>
        /// Gets or Sets the Password
        /// </summary>
        public string Password
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alan�na veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Picture
        /// </summary>
        public byte[] Picture
        { get; set; }
    }
}