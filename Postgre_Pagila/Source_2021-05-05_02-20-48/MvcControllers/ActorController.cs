using Pagila.Command.Actor;
using Pagila.Command.Base.Result;
using Pagila.Query.Actor;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using SimpleInfra.Validation;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class ActorController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public ActorController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<ActorReadAllQuery, ActorList>(new ActorReadAllQuery());
            return View(response.Data.Actors);
        }

        public ActionResult Create()
        {
            var model = new ActorViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(ActorViewModel model)
        {
            EntityValidationResult validationResult = model.Validate();
            if (validationResult.HasError)
            {
                ModelState.AddModelError(string.Empty, validationResult.AllValidationMessages);
                return View(nameof(Create), model);
            }
            var command = GetCommandFromViewModel<ActorInsertCommand, ActorViewModel>(model);
            var response = commandBus.Send<ActorInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? actorId)
        {
            var response = queryBus.Send<ActorReadByIdQuery, ActorResult>(new ActorReadByIdQuery { Id = actorId });

            if (response.Data?.Actor == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Actor);
        }

        public ActionResult Edit(int actorId)
        {
            var response = queryBus.Send<ActorReadByIdQuery, ActorResult>(new ActorReadByIdQuery { Id = actorId });

            if (response.Data?.Actor == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Actor);
        }

        [HttpPost]
        public ActionResult UpdatePost(ActorViewModel model)
        {
            EntityValidationResult validationResult = model.Validate();
            if (validationResult.HasError)
            {
                ModelState.AddModelError(string.Empty, validationResult.AllValidationMessages);
                return View(nameof(Create), model);
            }
            var command = GetCommandFromViewModel<ActorUpdateCommand, ActorViewModel>(model);
            var response = commandBus.Send<ActorUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int actorId)
        {
            var response = queryBus.Send<ActorReadByIdQuery, ActorResult>(new ActorReadByIdQuery { Id = actorId });

            if (response.Data?.Actor == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Actor);
        }

        [HttpPost]
        public ActionResult DeletePost(int? actorId)
        {
            var response = commandBus.Send<ActorDeleteCommand, LongCommandResult>(new ActorDeleteCommand { Id = actorId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { actorId });
            }
        }

        [HttpGet]
        public JsonResult ReadAll()
        {
            var response = queryBus.Send<ActorReadAllQuery, ActorList>(ActorReadAllQuery.GetEmptyInstance());
            return JsonResponse(response.Data.Actors);
        }
    }
}