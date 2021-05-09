using Pagila.Command.Actor;
using Pagila.Command.Base.Result;
using Pagila.Query.Actor;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class ActorController : PagilaBaseController
    {
        private ICommandBus commandBus;
        private IQueryBus queryBus;

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
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(ActorViewModel model)
        {
            var command = GetCommandFromViewModel<ActorInsertCommand, ActorViewModel>(model);
            var response = commandBus.Send<ActorInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
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

            return View("Edit", response.Data.Actor);
        }

        [HttpPost]
        public ActionResult UpdatePost(ActorViewModel model)
        {
            var command = GetCommandFromViewModel<ActorUpdateCommand, ActorViewModel>(model);
            var response = commandBus.Send<ActorUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int actorId)
        {
            var response = queryBus.Send<ActorReadByIdQuery, ActorResult>(new ActorReadByIdQuery { Id = actorId });

            if (response.Data?.Actor == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data.Actor);
        }

        [HttpPost]
        public ActionResult DeletePost(int? actorId)
        {
            var response = commandBus.Send<ActorDeleteCommand, LongCommandResult>(new ActorDeleteCommand { Id = actorId });

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { actorId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = queryBus.Send<ActorReadAllQuery, ActorList>(new ActorReadAllQuery());
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}