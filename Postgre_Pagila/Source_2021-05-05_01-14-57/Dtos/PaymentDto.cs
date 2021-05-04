using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class PaymentDto : SimpleBaseDto
    {
        [DataMember]
        public int PaymentId
        { get; set; }

        [DataMember]
        public int CustomerId
        { get; set; }

        [DataMember]
        public int StaffId
        { get; set; }

        [DataMember]
        public int RentalId
        { get; set; }

        [DataMember]
        public  Amount
        { get; set; }

        [DataMember]
        public DateTime PaymentDate
        { get; set; }
    }
}