using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class PaymentViewModel
    {
        /// <summary>
        /// Gets or Sets the PaymentId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentId alanýna veri girilmelidir.")]
        public int PaymentId
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerId alanýna veri girilmelidir.")]
        public int CustomerId
        { get; set; }

        /// <summary>
        /// Gets or Sets the StaffId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StaffId alanýna veri girilmelidir.")]
        public int StaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalId alanýna veri girilmelidir.")]
        public int RentalId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Amount
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount alanýna veri girilmelidir.")]
        public decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or Sets the PaymentDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentDate alanýna veri girilmelidir.")]
        public DateTime PaymentDate
        { get; set; }
    }
}