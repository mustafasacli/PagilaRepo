using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class CustomerDto : SimpleBaseDto
    {
        [DataMember]
        public int CustomerId
        { get; set; }

        [DataMember]
        public int StoreId
        { get; set; }

        [DataMember]
        public string FirstName
        { get; set; }

        [DataMember]
        public string LastName
        { get; set; }

        [DataMember]
        public string Email
        { get; set; }

        [DataMember]
        public int AddressId
        { get; set; }

        [DataMember]
        public bool Activebool
        { get; set; }

        [DataMember]
        public DateTime CreateDate
        { get; set; }

        [DataMember]
        public DateTime? LastUpdate
        { get; set; }

        [DataMember]
        public int? Active
        { get; set; }
    }
}