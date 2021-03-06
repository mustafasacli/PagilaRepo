using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("address", Schema = "public")]
    public class AddressEntity
    {
        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alanưna veri girilmelidir.")]
        [Column("address_id", Order = 1, TypeName = "int4")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Address
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address alanưna veri girilmelidir.")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "District alanưna veri girilmelidir.")]
        [Column("district", Order = 4, TypeName = "text")]
        public string District
        { get; set; }

        /// <summary>
        /// Gets or Sets the CityId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CityId alanưna veri girilmelidir.")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone alanưna veri girilmelidir.")]
        [Column("phone", Order = 7, TypeName = "text")]
        public string Phone
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanưna veri girilmelidir.")]
        [Column("last_update", Order = 8, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        [ForeignKey("CityId")]
        public virtual CityEntity City
        { get; set; }

        public virtual ICollection<CustomerEntity> CustomerList
        { get; set; }

        public virtual ICollection<StaffEntity> StaffList
        { get; set; }

        public virtual ICollection<StoreEntity> StoreList
        { get; set; }
    }
}