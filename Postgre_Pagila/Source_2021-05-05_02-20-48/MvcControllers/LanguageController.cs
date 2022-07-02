using Pagila.Command.Base.Result;
using Pagila.Command.Language;
using Pagila.Query.Language;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class LanguageController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public LanguageController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<LanguageReadAllQuery, LanguageList>(new LanguageReadAllQuery());
            return View(response.Data.Languages);
        }

        public ActionResult Create()
        {
            var model = new LanguageViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(LanguageViewModel model)
        {
            var command = GetCommandFromViewModel<LanguageInsertCommand, LanguageViewModel>(model);
            var response = commandBus.Send<LanguageInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? LanguageId)
        {
            var response = queryBus.Send<LanguageReadByIdQuery, LanguageResult>(new LanguageReadByIdQuery { Id = LanguageId });

            if (response.Data?.Language == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Language);
        }

        public ActionResult Edit(int LanguageId)
        {
            var response = queryBus.Send<LanguageReadByIdQuery, LanguageResult>(new LanguageReadByIdQuery { Id = LanguageId });

            if (response.Data?.Language == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Language);
        }

        [HttpPost]
        public ActionResult UpdatePost(LanguageViewModel model)
        {
            var command = GetCommandFromViewModel<LanguageUpdateCommand, LanguageViewModel>(model);
            var response = commandBus.Send<LanguageUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int LanguageId)
        {
            var response = queryBus.Send<LanguageReadByIdQuery, LanguageResult>(new LanguageReadByIdQuery { Id = LanguageId });

            if (response.Data?.Language == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Language);
        }

        [HttpPost]
        public ActionResult DeletePost(int? LanguageId)
        {
            var response = commandBus.Send<LanguageDeleteCommand, LongCommandResult>(new LanguageDeleteCommand { Id = LanguageId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { LanguageId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = queryBus.Send<LanguageReadAllQuery, LanguageList>(LanguageReadAllQuery.GetEmptyInstance());
            return Json(response.Data.Languages, JsonRequestBehavior.AllowGet);
        }
    }
}