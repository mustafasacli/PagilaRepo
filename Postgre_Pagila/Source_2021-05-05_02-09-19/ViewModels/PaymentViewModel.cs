using System;
using System.ComponentModel.DataAnnotations;

namespace Pagila.ViewModel
{
    public class PaymentViewModel
    {
        /// <summary>
        /// Gets or Sets the PaymentId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentId alan�na veri girilmelidir.")]
        public int PaymentId
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerId alan�na veri girilmelidir.")]
        public int CustomerId
        { get; set; }

        /// <summary>
        /// Gets or Sets the StaffId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StaffId alan�na veri girilmelidir.")]
        public int StaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the RentalId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RentalId alan�na veri girilmelidir.")]
        public int RentalId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Amount
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount alan�na veri girilmelidir.")]
        public decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or Sets the PaymentDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentDate alan�na veri girilmelidir.")]
        public DateTime PaymentDate
        { get; set; }
    }
}