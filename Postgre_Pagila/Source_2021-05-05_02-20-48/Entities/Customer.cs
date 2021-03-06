using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("customer", Schema = "public")]
    public class CustomerEntity
    {
        /// <summary>
        /// Gets or Sets the CustomerId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerId alanưna veri girilmelidir.")]
        [Column("customer_id", Order = 1, TypeName = "int4")]
        public int CustomerId
        { get; set; }

        /// <summary>
        /// Gets or Sets the StoreId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StoreId alanưna veri girilmelidir.")]
        [Column("store_id", Order = 2, TypeName = "int2")]
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the FirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName alanưna veri girilmelidir.")]
        [Column("first_name", Order = 3, TypeName = "text")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName alanưna veri girilmelidir.")]
        [Column("last_name", Order = 4, TypeName = "text")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the Email
        /// </summary>
        [Column("email", Order = 5, TypeName = "text")]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alanưna veri girilmelidir.")]
        [Column("address_id", Order = 6, TypeName = "int2")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Activebool
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Activebool alanưna veri girilmelidir.")]
        [Column("activebool", Order = 7, TypeName = "bool")]
        public bool Activebool
        { get; set; }

        /// <summary>
        /// Gets or Sets the CreateDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CreateDate alanưna veri girilmelidir.")]
        [Column("create_date", Order = 8, TypeName = "date")]
        public DateTime CreateDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Column("last_update", Order = 9, TypeName = "timestamptz")]
        public DateTime? LastUpdate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Active
        /// </summary>
        [Column("active", Order = 10, TypeName = "int4")]
        public int? Active
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