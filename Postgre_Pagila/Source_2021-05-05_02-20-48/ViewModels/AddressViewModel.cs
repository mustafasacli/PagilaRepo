using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class AddressViewModel
    {
        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alan�na veri girilmelidir.")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Address
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address alan�na veri girilmelidir.")]
        public string Address
        { get; set; }

        /// <summary>
        /// Gets or Sets the Address2
        /// </summary>
        public string Address2
        { get; set; }

        /// <summary>
        /// Gets or Sets the District
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "District alan�na veri girilmelidir.")]
        public string District
        { get; set; }

        /// <summary>
        /// Gets or Sets the CityId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CityId alan�na veri girilmelidir.")]
        public int CityId
        { get; set; }

        /// <summary>
        /// Gets or Sets the PostalCode
        /// </summary>
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Phone
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone alan�na veri girilmelidir.")]
        public string Phone
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alan�na veri girilmelidir.")]
        public DateTime LastUpdate
        { get; set; }
    }
}