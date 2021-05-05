using Pagila.Command.Base;

namespace Pagila.Command.Actor
{
    public class ActorUpdateCommand : BaseUpdateCommand
    {
        public int ActorId
        { get; set; }

        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }
    }
}