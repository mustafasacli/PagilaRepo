namespace Pagila.Command.Base
{
    using Command.Base.Result;
    using SI.Command.Core;
    using System;

    public interface IUpdateCommand : ICommand<LongCommandResult>
    {
        DateTime LastUpdate { get; set; }

        bool Active { get; set; }
    }
}