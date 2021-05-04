using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class ActorDto : SimpleBaseDto
    {
        [DataMember]
        public int ActorId
        { get; set; }

        [DataMember]
        public string FirstName
        { get; set; }

        [DataMember]
        public string LastName
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}