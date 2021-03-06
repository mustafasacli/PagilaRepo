using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("payment", Schema = "public")]
    public class PaymentEntity
    {
        /// <summary>
        /// Gets or Sets the PaymentId
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentId alanưna veri girilmelidir.")]
        [Column("payment_id", Order = 1, TypeName = "int4")]
        public int PaymentId
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerId alanưna veri girilmelidir.")]
        [Column("customer_id", Order = 2, TypeName = "int2")]
        public int CustomerId
        { get; set; }

        /// <summary>
        /// Gets or Sets the StaffId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StaffId alanưna veri girilmelidir.")]
        [Column("staff_id", Order = 3, TypeName = "int2")]
        public int StaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalId alanưna veri girilmelidir.")]
        [Column("rental_id", Order = 4, TypeName = "int4")]
        public int RentalId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Amount
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount alanưna veri girilmelidir.")]
        [Column("amount", Order = 5, TypeName = "numeric")]
        public decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or Sets the PaymentDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentDate alanưna veri girilmelidir.")]
        [Column("payment_date", Order = 6, TypeName = "timestamptz")]
        public DateTime PaymentDate
        { get; set; }
    }
}