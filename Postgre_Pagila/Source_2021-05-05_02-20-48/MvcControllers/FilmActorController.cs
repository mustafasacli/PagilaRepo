using SI.CommandBus.Core;
using SI.QueryBus.Core;

namespace Pagila.WebUI.Controllers
{
    public class FilmActorController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public FilmActorController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }
    }
}