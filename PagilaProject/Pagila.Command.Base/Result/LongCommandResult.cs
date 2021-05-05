using SI.Command.Core;

namespace Pagila.Command.Base.Result
{
    public class LongCommandResult : ICommandResult
    {
        public long? ReturnValue { get; set; }
    }
}