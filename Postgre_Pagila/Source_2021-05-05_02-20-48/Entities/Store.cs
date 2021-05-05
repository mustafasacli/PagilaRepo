using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("store", Schema = "public")]
    public class StoreEntity
    {
        /// <summary>
        /// Gets or Sets the StoreId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "StoreId alanýna veri girilmelidir.")]
        [Column("store_id", Order = 1, TypeName = "int4")]
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the ManagerStaffId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ManagerStaffId alanýna veri girilmelidir.")]
        [Column("manager_staff_id", Order = 2, TypeName = "int2")]
        public int ManagerStaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressId alanýna veri girilmelidir.")]
        [Column("address_id", Order = 3, TypeName = "int2")]
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        [Column("last_update", Order = 4, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        [ForeignKey("AddressId")]
        public virtual AddressEntity Address
        { get; set; }

        public virtual ICollection<CustomerEntity> CustomerList
        { get; set; }

        public virtual ICollection<InventoryEntity> InventoryList
        { get; set; }

        public virtual ICollection<StaffEntity> StaffList
        { get; set; }
    }
}