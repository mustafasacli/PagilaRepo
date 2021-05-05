using Pagila.Command.Base;

namespace Pagila.Command.Actor
{
    public class ActorInsertCommand : BaseInsertCommand
    {
        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }
    }
}