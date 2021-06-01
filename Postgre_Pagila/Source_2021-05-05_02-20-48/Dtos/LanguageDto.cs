
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class LanguageDto
    {
        [DataMember]
        public int LanguageId
        { get; set; }

        [DataMember]
        public string Name
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}