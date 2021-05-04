using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("film_actor", Schema = "public")]
    public class FilmActor
    {
        /// <summary>
        /// Gets or Sets the ActorId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ActorId alanýna veri girilmelidir.")]
        [Column("actor_id", Order = 1, TypeName = "int2")]
        public int ActorId
        { get; set; }

        /// <summary>
        /// Gets or Sets the FilmId
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FilmId alanýna veri girilmelidir.")]
        [Column("film_id", Order = 2, TypeName = "int2")]
        public int FilmId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanýna veri girilmelidir.")]
        [Column("last_update", Order = 3, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        [ForeignKey("FilmId")]
        public virtual Film Film
        { get; set; }

        [ForeignKey("ActorId")]
        public virtual Actor Actor
        { get; set; }
    }
}