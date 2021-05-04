using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class FilmActorDto : SimpleBaseDto
    {
        [DataMember]
        public int ActorId
        { get; set; }

        [DataMember]
        public int FilmId
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}