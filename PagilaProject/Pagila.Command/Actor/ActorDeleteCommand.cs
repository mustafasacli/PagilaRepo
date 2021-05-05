using Pagila.Command.Base;

namespace Pagila.Command.Actor
{
    public class ActorDeleteCommand : BaseDeleteCommand
    {
        public int Id
        { get; set; }
    }
}