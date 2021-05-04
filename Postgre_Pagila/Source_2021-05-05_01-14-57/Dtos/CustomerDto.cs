
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class CustomerDto
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
        public  Activebool
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