
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class RentalDto
    {
        [DataMember]
        public int RentalId
        { get; set; }

        [DataMember]
        public DateTime RentalDate
        { get; set; }

        [DataMember]
        public int InventoryId
        { get; set; }

        [DataMember]
        public int CustomerId
        { get; set; }

        [DataMember]
        public DateTime? ReturnDate
        { get; set; }

        [DataMember]
        public int StaffId
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }
    }
}