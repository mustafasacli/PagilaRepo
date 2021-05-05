
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class CategoryDto
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