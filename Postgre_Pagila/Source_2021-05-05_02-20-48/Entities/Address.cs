using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("address", Schema = "public")]
    public class Address
    {
        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alanýna veri girilmelidir.")]
        [Column("address_id", Order = 1, TypeName = "int4")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Address
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address alanýna veri girilmelidir.")]
        [Column("address", Order = 2, TypeName = "text")]
        public string Address
        { get; set; }

        /// <summary>
        /// Gets or Sets the Address2
        /// </summary>
        [Column("address2", Order = 3, TypeName = "text")]
        public string Address2
        { get; set; }

        /// <summary>
        /// Gets or Sets the District
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "District alanýna veri girilmelidir.")]
        [Column("district", Order = 4, TypeName = "text")]
        public string District
        { get; set; }

        /// <summary>
        /// Gets or Sets the CityId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CityId alanýna veri girilmelidir.")]
        [Column("city_id", Order = 5, TypeName = "int2")]
        public int CityId
        { get; set; }

        /// <summary>
        /// Gets or Sets the PostalCode
        /// </summary>
        [Column("postal_code", Order = 6, TypeName = "text")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Phone
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone alanýna veri girilmelidir.")]
        [Column("phone", Order = 7, TypeName = "text")]
        public string Phone
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        [Column("last_update", Order = 8, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        [ForeignKey("CityId")]
        public virtual City City
        { get; set; }

        public virtual ICollection<Customer> CustomerList
        { get; set; }

        public virtual ICollection<Staff> StaffList
        { get; set; }

        public virtual ICollection<Store> StoreList
        { get; set; }
    }
}