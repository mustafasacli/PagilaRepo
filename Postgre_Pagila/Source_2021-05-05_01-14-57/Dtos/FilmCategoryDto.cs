using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class FilmCategoryDto : SimpleBaseDto
    {
        [DataMember]
        public int FilmId
        { get; set; }

        [DataMember]
        public int CategoryId
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}