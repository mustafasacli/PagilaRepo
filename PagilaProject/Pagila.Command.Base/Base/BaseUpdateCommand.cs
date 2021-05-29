namespace Pagila.Command.Base
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using static System.DateTime;

    public abstract class BaseUpdateCommand : IUpdateCommand
    {
        private DateTime? _updatedOn = null;

        [DataMember]
        [Column("last_update", Order = 3, TypeName = "timestamp")]
        public DateTime LastUpdate
        {
            get { return _updatedOn ?? Now; }
            set { _updatedOn = value; }
        }
        
        [DataMember]
        [Column("active", Order = 7, TypeName = "bool")]
        public bool Active
        { get; set; } = true;
    }
}