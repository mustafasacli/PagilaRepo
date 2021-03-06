using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class CustomerViewModel
    {
        /// <summary>
        /// Gets or Sets the CustomerId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerId alanưna veri girilmelidir.")]
        public int CustomerId
        { get; set; }

        /// <summary>
        /// Gets or Sets the StoreId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StoreId alanưna veri girilmelidir.")]
        public int StoreId
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
        /// Gets or Sets the Email
        /// </summary>
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alanưna veri girilmelidir.")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Activebool
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Activebool alanưna veri girilmelidir.")]
        public bool Activebool
        { get; set; }

        /// <summary>
        /// Gets or Sets the CreateDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CreateDate alanưna veri girilmelidir.")]
        public DateTime CreateDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        public DateTime? LastUpdate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Active
        /// </summary>
        public int? Active
        { get; set; }
    }
}