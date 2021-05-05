namespace Pagila.Command.Base
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using static System.DateTime;

    public class BaseInsertCommand : IInsertCommand
    {
        private DateTime? _createdOn = null;

        [DataMember]
        [Column("last_update", Order = 3, TypeName = "timestamp")]
        public DateTime LastUpdate
        {
            get { return _createdOn ?? Now; }
            set { _createdOn = value; }
        }

        [DataMember]
        [Column("active", Order = 7, TypeName = "bool")]
        public bool Active
        { get; set; } = true;
    }
}