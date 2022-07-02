using Pagila.Command.Base.Result;
using Pagila.Command.Inventory;
using Pagila.Query.Inventory;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class InventoryController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public InventoryController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<InventoryReadAllQuery, InventoryList>(new InventoryReadAllQuery());
            return View(response.Data.Inventories);
        }

        public ActionResult Create()
        {
            var model = new InventoryViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(InventoryViewModel model)
        {
            var command = GetCommandFromViewModel<InventoryInsertCommand, InventoryViewModel>(model);
            var response = commandBus.Send<InventoryInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? InventoryId)
        {
            var response = queryBus.Send<InventoryReadByIdQuery, InventoryResult>(new InventoryReadByIdQuery { Id = InventoryId });

            if (response.Data?.Inventory == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Inventory);
        }

        public ActionResult Edit(int InventoryId)
        {
            var response = queryBus.Send<InventoryReadByIdQuery, InventoryResult>(new InventoryReadByIdQuery { Id = InventoryId });

            if (response.Data?.Inventory == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Inventory);
        }

        [HttpPost]
        public ActionResult UpdatePost(InventoryViewModel model)
        {
            var command = GetCommandFromViewModel<InventoryUpdateCommand, InventoryViewModel>(model);
            var response = commandBus.Send<InventoryUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int InventoryId)
        {
            var response = queryBus.Send<InventoryReadByIdQuery, InventoryResult>(new InventoryReadByIdQuery { Id = InventoryId });

            if (response.Data?.Inventory == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Inventory);
        }

        [HttpPost]
        public ActionResult DeletePost(int? InventoryId)
        {
            var response = commandBus.Send<InventoryDeleteCommand, LongCommandResult>(new InventoryDeleteCommand { Id = InventoryId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { InventoryId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = queryBus.Send<InventoryReadAllQuery, InventoryList>(InventoryReadAllQuery.GetEmptyInstance());
            return Json(response.Data.Inventories, JsonRequestBehavior.AllowGet);
        }
    }
}