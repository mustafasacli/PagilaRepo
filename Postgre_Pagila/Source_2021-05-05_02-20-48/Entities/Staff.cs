using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("staff", Schema = "public")]
    public class StaffEntity
    {
        /// <summary>
        /// Gets or Sets the StaffId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "StaffId alanýna veri girilmelidir.")]
        [Column("staff_id", Order = 1, TypeName = "int4")]
        public int StaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the FirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName alanýna veri girilmelidir.")]
        [Column("first_name", Order = 2, TypeName = "text")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName alanýna veri girilmelidir.")]
        [Column("last_name", Order = 3, TypeName = "text")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alanýna veri girilmelidir.")]
        [Column("address_id", Order = 4, TypeName = "int2")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Email
        /// </summary>
        [Column("email", Order = 5, TypeName = "text")]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or Sets the StoreId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StoreId alanýna veri girilmelidir.")]
        [Column("store_id", Order = 6, TypeName = "int2")]
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Active
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Active alanýna veri girilmelidir.")]
        [Column("active", Order = 7, TypeName = "bool")]
        public bool Active
        { get; set; }

        /// <summary>
        /// Gets or Sets the Username
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username alanýna veri girilmelidir.")]
        [Column("username", Order = 8, TypeName = "text")]
        public string Username
        { get; set; }

        /// <summary>
        /// Gets or Sets the Password
        /// </summary>
        [Column("password", Order = 9, TypeName = "text")]
        public string Password
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        [Column("last_update", Order = 10, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Picture
        /// </summary>
        [Column("picture", Order = 11, TypeName = "bytea")]
        public byte[] Picture
        { get; set; }

        [ForeignKey("StoreId")]
        public virtual StoreEntity Store
        { get; set; }

        [ForeignKey("AddressId")]
        public virtual AddressEntity Address
        { get; set; }

        public virtual ICollection<RentalEntity> RentalList
        { get; set; }
    }
}