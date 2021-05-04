using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class StoreDto : SimpleBaseDto
    {
        [DataMember]
        public int StoreId
        { get; set; }

        [DataMember]
        public int ManagerStaffId
        { get; set; }

        [DataMember]
        public int AddressId
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}