using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class LanguageDto : SimpleBaseDto
    {
        [DataMember]
        public int LanguageId
        { get; set; }

        [DataMember]
        public char Name
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}