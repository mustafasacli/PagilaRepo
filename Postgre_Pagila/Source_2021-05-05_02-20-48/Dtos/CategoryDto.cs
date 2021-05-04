using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class CategoryDto : SimpleBaseDto
    {
        [DataMember]
        public int CategoryId
        { get; set; }

        [DataMember]
        public string Name
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}