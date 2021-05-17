using SimpleInfra.Mapping;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public abstract class PagilaBaseController : Controller
    {
        protected TCommand GetCommandFromViewModel<TCommand, TViewModel>(TViewModel viewModel)
            where TCommand : class, new()
            where TViewModel : class
        {
            TCommand command = SimpleMapper.Map<TViewModel, TCommand>(viewModel);
            return command;
        }
    }
}