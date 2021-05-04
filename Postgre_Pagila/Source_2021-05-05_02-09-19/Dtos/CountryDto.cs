
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class CountryDto
    {
        [DataMember]
        public int CountryId
        { get; set; }

        [DataMember]
        public string Country
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}