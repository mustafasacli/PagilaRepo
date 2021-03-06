using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class PaymentViewModel
    {
        /// <summary>
        /// Gets or Sets the PaymentId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentId alanưna veri girilmelidir.")]
        public int PaymentId
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerId alanưna veri girilmelidir.")]
        public int CustomerId
        { get; set; }

        /// <summary>
        /// Gets or Sets the StaffId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StaffId alanưna veri girilmelidir.")]
        public int StaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalId alanưna veri girilmelidir.")]
        public int RentalId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Amount
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount alanưna veri girilmelidir.")]
        public decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or Sets the PaymentDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentDate alanưna veri girilmelidir.")]
        public DateTime PaymentDate
        { get; set; }
    }
}