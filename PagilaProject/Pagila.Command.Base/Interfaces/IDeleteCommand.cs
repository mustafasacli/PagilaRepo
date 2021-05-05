namespace Pagila.Command.Base
{
    using Command.Base.Result;
    using SI.Command.Core;

    public interface IDeleteCommand : ICommand<LongCommandResult>
    {
    }
}