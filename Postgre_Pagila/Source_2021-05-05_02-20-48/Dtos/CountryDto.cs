using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class CountryDto : SimpleBaseDto
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