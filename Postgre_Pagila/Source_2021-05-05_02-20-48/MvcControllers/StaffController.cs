using Pagila.Command.Base.Result;
using Pagila.Command.Staff;
using Pagila.Query.Staff;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class StaffController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public StaffController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<StaffReadAllQuery, StaffList>(new StaffReadAllQuery());
            return View(response.Data.Staffs);
        }

        public ActionResult Create()
        {
            var model = new StaffViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(StaffViewModel model)
        {
            var command = GetCommandFromViewModel<StaffInsertCommand, StaffViewModel>(model);
            var response = commandBus.Send<StaffInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? StaffId)
        {
            var response = queryBus.Send<StaffReadByIdQuery, StaffResult>(new StaffReadByIdQuery { Id = StaffId });

            if (response.Data?.Staff == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Staff);
        }

        public ActionResult Edit(int StaffId)
        {
            var response = queryBus.Send<StaffReadByIdQuery, StaffResult>(new StaffReadByIdQuery { Id = StaffId });

            if (response.Data?.Staff == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Staff);
        }

        [HttpPost]
        public ActionResult UpdatePost(StaffViewModel model)
        {
            var command = GetCommandFromViewModel<StaffUpdateCommand, StaffViewModel>(model);
            var response = commandBus.Send<StaffUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int StaffId)
        {
            var response = queryBus.Send<StaffReadByIdQuery, StaffResult>(new StaffReadByIdQuery { Id = StaffId });

            if (response.Data?.Staff == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Staff);
        }

        [HttpPost]
        public ActionResult DeletePost(int? StaffId)
        {
            var response = commandBus.Send<StaffDeleteCommand, LongCommandResult>(new StaffDeleteCommand { Id = StaffId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { StaffId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = queryBus.Send<StaffReadAllQuery, StaffList>(StaffReadAllQuery.GetEmptyInstance());
            return Json(response.Data.Staffs, JsonRequestBehavior.AllowGet);
        }
    }
}