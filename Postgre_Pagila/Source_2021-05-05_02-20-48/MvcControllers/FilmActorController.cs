
using Pagila.ViewModel;using SI.CommandBus.Core;using SI.QueryBus.Core;


using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class FilmActorController : PagilaBaseController
    {
        private IFilmActorBusiness iFilmActorBusiness;
        private ICommandBus commandBus;
        private IQueryBus queryBus;

        public FilmActorController(IFilmActorBusiness iFilmActorBusiness = null, ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
            this.iFilmActorBusiness = iFilmActorBusiness ??
                GsbIoC.Instance.GetInstance<IFilmActorBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iFilmActorBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new FilmActorViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(FilmActorViewModel model)
        {
            var response = iFilmActorBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int actorId, int filmId)
        {
            var response = iFilmActorBusiness.Read(actorId, filmId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int actorId, int filmId)
        {
            var response = iFilmActorBusiness.Read(actorId, filmId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(FilmActorViewModel model)
        {
            var response = iFilmActorBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int actorId, int filmId)
        {
            var response = iFilmActorBusiness.Read(actorId, filmId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int actorId, int filmId)
        {
            var response = iFilmActorBusiness.Delete(actorId, filmId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { actorId, filmId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iFilmActorBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}