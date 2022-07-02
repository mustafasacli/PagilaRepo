using Pagila.Command.Base.Result;
using Pagila.Command.Film;
using Pagila.Query.Film;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class FilmController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public FilmController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<FilmReadAllQuery, FilmList>(new FilmReadAllQuery());
            return View(response.Data.Films);
        }

        public ActionResult Create()
        {
            var model = new FilmViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(FilmViewModel model)
        {
            var command = GetCommandFromViewModel<FilmInsertCommand, FilmViewModel>(model);
            var response = commandBus.Send<FilmInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? FilmId)
        {
            var response = queryBus.Send<FilmReadByIdQuery, FilmResult>(new FilmReadByIdQuery { Id = FilmId });

            if (response.Data?.Film == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Film);
        }

        public ActionResult Edit(int FilmId)
        {
            var response = queryBus.Send<FilmReadByIdQuery, FilmResult>(new FilmReadByIdQuery { Id = FilmId });

            if (response.Data?.Film == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Film);
        }

        [HttpPost]
        public ActionResult UpdatePost(FilmViewModel model)
        {
            var command = GetCommandFromViewModel<FilmUpdateCommand, FilmViewModel>(model);
            var response = commandBus.Send<FilmUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int FilmId)
        {
            var response = queryBus.Send<FilmReadByIdQuery, FilmResult>(new FilmReadByIdQuery { Id = FilmId });

            if (response.Data?.Film == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Film);
        }

        [HttpPost]
        public ActionResult DeletePost(int? FilmId)
        {
            var response = commandBus.Send<FilmDeleteCommand, LongCommandResult>(new FilmDeleteCommand { Id = FilmId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { FilmId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = queryBus.Send<FilmReadAllQuery, FilmList>(FilmReadAllQuery.GetEmptyInstance());
            return Json(response.Data.Films, JsonRequestBehavior.AllowGet);
        }
    }
}