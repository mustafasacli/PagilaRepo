using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class InventoryDto : SimpleBaseDto
    {
        [DataMember]
        public int InventoryId
        { get; set; }

        [DataMember]
        public int FilmId
        { get; set; }

        [DataMember]
        public int StoreId
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}