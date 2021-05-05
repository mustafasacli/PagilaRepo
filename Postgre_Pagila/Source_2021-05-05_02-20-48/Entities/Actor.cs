using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("actor", Schema = "public")]
    public class ActorEntity
    {
        /// <summary>
        /// Gets or Sets the ActorId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ActorId alan�na veri girilmelidir.")]
        [Column("actor_id", Order = 1, TypeName = "int4")]
        public int ActorId
        { get; set; }

        /// <summary>
        /// Gets or Sets the FirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName alan�na veri girilmelidir.")]
        [Column("first_name", Order = 2, TypeName = "text")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName alan�na veri girilmelidir.")]
        [Column("last_name", Order = 3, TypeName = "text")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alan�na veri girilmelidir.")]
        [Column("last_update", Order = 4, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        public virtual ICollection<FilmActorEntity> FilmActorList
        { get; set; }
    }
}