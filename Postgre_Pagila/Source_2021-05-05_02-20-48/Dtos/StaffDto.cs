using SimpleInfra.Dto.Core;
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class StaffDto : SimpleBaseDto
    {
        [DataMember]
        public int StaffId
        { get; set; }

        [DataMember]
        public string FirstName
        { get; set; }

        [DataMember]
        public string LastName
        { get; set; }

        [DataMember]
        public int AddressId
        { get; set; }

        [DataMember]
        public string Email
        { get; set; }

        [DataMember]
        public int StoreId
        { get; set; }

        [DataMember]
        public bool Active
        { get; set; }

        [DataMember]
        public string Username
        { get; set; }

        [DataMember]
        public string Password
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }

        [DataMember]
        public byte[] Picture
        { get; set; }
    }
}