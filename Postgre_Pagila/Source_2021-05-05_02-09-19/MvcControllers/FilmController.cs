using Pagila.Business.Interfaces;
using Pagila.ViewModel;
using SimpleInfra.Common.Core;
using Gsb.IoC;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Pagila.Web.Controllers
{
    public class FilmController : OzelYurtBaseController
    {
        private IFilmBusiness iFilmBusiness;

        public FilmController(IFilmBusiness iFilmBusiness = null)
        {
            this.iFilmBusiness = iFilmBusiness ??
                GsbIoC.Instance.GetInstance<IFilmBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iFilmBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new FilmViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(FilmViewModel model)
        {
            var response = iFilmBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int filmId)
        {
            var response = iFilmBusiness.Read(filmId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int filmId)
        {
            var response = iFilmBusiness.Read(filmId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(FilmViewModel model)
        {
            var response = iFilmBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int filmId)
        {
            var response = iFilmBusiness.Read(filmId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int filmId)
        {
            var response = iFilmBusiness.Delete(filmId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { filmId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iFilmBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}