using Pagila.Command.Base.Result;
using Pagila.Command.Store;
using Pagila.Query.Store;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class StoreController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public StoreController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<StoreReadAllQuery, StoreList>(new StoreReadAllQuery());
            return View(response.Data.Stores);
        }

        public ActionResult Create()
        {
            var model = new StoreViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(StoreViewModel model)
        {
            var command = GetCommandFromViewModel<StoreInsertCommand, StoreViewModel>(model);
            var response = commandBus.Send<StoreInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? StoreId)
        {
            var response = queryBus.Send<StoreReadByIdQuery, StoreResult>(new StoreReadByIdQuery { Id = StoreId });

            if (response.Data?.Store == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Store);
        }

        public ActionResult Edit(int StoreId)
        {
            var response = queryBus.Send<StoreReadByIdQuery, StoreResult>(new StoreReadByIdQuery { Id = StoreId });

            if (response.Data?.Store == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Store);
        }

        [HttpPost]
        public ActionResult UpdatePost(StoreViewModel model)
        {
            var command = GetCommandFromViewModel<StoreUpdateCommand, StoreViewModel>(model);
            var response = commandBus.Send<StoreUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int StoreId)
        {
            var response = queryBus.Send<StoreReadByIdQuery, StoreResult>(new StoreReadByIdQuery { Id = StoreId });

            if (response.Data?.Store == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Store);
        }

        [HttpPost]
        public ActionResult DeletePost(int? StoreId)
        {
            var response = commandBus.Send<StoreDeleteCommand, LongCommandResult>(new StoreDeleteCommand { Id = StoreId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { StoreId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = queryBus.Send<StoreReadAllQuery, StoreList>(StoreReadAllQuery.GetEmptyInstance());
            return Json(response.Data.Stores, JsonRequestBehavior.AllowGet);
        }
    }
}