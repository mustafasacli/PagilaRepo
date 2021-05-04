using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("rental", Schema = "public")]
    public class Rental
    {
        /// <summary>
        /// Gets or Sets the RentalId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalId alanýna veri girilmelidir.")]
        [Column("rental_id", Order = 1, TypeName = "int4")]
        public int RentalId
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalDate alanýna veri girilmelidir.")]
        [Column("rental_date", Order = 2, TypeName = "timestamptz")]
        public DateTime RentalDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the InventoryId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "InventoryId alanýna veri girilmelidir.")]
        [Column("inventory_id", Order = 3, TypeName = "int4")]
        public int InventoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerId alanýna veri girilmelidir.")]
        [Column("customer_id", Order = 4, TypeName = "int2")]
        public int CustomerId
        { get; set; }

        /// <summary>
        /// Gets or Sets the ReturnDate
        /// </summary>
        [Column("return_date", Order = 5, TypeName = "timestamptz")]
        public DateTime? ReturnDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the StaffId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StaffId alanýna veri girilmelidir.")]
        [Column("staff_id", Order = 6, TypeName = "int2")]
        public int StaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        [Column("last_update", Order = 7, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        [ForeignKey("StaffId")]
        public virtual Staff Staff
        { get; set; }

        [ForeignKey("InventoryId")]
        public virtual Inventory Inventory
        { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer
        { get; set; }
    }
}