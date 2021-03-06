using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagila.Entity
{
    [Table("inventory", Schema = "public")]
    public class InventoryEntity
    {
        /// <summary>
        /// Gets or Sets the InventoryId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "InventoryId alanưna veri girilmelidir.")]
        [Column("inventory_id", Order = 1, TypeName = "int4")]
        public int InventoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the FilmId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FilmId alanưna veri girilmelidir.")]
        [Column("film_id", Order = 2, TypeName = "int2")]
        public int FilmId
        { get; set; }

        /// <summary>
        /// Gets or Sets the StoreId
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "StoreId alanưna veri girilmelidir.")]
        [Column("store_id", Order = 3, TypeName = "int2")]
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastUpdate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastUpdate alanưna veri girilmelidir.")]
        [Column("last_update", Order = 4, TypeName = "timestamptz")]
        public DateTime LastUpdate
        { get; set; }

        [ForeignKey("StoreId")]
        public virtual StoreEntity Store
        { get; set; }

        [ForeignKey("FilmId")]
        public virtual FilmEntity Film
        { get; set; }

        public virtual ICollection<RentalEntity> RentalList
        { get; set; }
    }
}