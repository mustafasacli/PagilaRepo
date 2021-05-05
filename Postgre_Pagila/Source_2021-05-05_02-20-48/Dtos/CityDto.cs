
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class CityDto
    {
        [DataMember]
        public int CityId
        { get; set; }

        [DataMember]
        public string City
        { get; set; }

        [DataMember]
        public int CountryId
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}