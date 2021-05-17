using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class AddressDto
    {
        [DataMember]
        public int AddressId
        { get; set; }

        [DataMember]
        public string Address
        { get; set; }

        [DataMember]
        public string Address2
        { get; set; }

        [DataMember]
        public string District
        { get; set; }

        [DataMember]
        public int CityId
        { get; set; }

        [DataMember]
        public string PostalCode
        { get; set; }

        [DataMember]
        public string Phone
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}