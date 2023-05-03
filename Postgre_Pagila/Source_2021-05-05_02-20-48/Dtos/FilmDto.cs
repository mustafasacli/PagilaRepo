
using System;
using System.Runtime.Serialization;

namespace Pagila.Dtos
{
    [DataContract]
    public class FilmDto
    {
        [DataMember]
        public int FilmId
        { get; set; }

        [DataMember]
        public string Title
        { get; set; }

        [DataMember]
        public string Description
        { get; set; }

        [DataMember]
        public int? ReleaseYear
        { get; set; }

        [DataMember]
        public short LanguageId
        { get; set; }

        [DataMember]
        public short? OriginalLanguageId
        { get; set; }

        [DataMember]
        public int RentalDuration
        { get; set; }

        [DataMember]
        public decimal RentalRate
        { get; set; }

        [DataMember]
        public short? Length
        { get; set; }

        [DataMember]
        public decimal ReplacementCost
        { get; set; }

        [DataMember]
        public decimal? Rating
        { get; set; }

        [DataMember]
        public DateTime LastUpdate
        { get; set; }

        [DataMember]
        public string SpecialFeatures
        { get; set; }

        [DataMember]
        public string Fulltext
        { get; set; }
    }
}