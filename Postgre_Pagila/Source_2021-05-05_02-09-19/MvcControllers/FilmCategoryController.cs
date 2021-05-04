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
    public class FilmCategoryController : OzelYurtBaseController
    {
        private IFilmCategoryBusiness iFilmCategoryBusiness;

        public FilmCategoryController(IFilmCategoryBusiness iFilmCategoryBusiness = null)
        {
            this.iFilmCategoryBusiness = iFilmCategoryBusiness ??
                GsbIoC.Instance.GetInstance<IFilmCategoryBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iFilmCategoryBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new FilmCategoryViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(FilmCategoryViewModel model)
        {
            var response = iFilmCategoryBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int filmId, int categoryId)
        {
            var response = iFilmCategoryBusiness.Read(filmId, categoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int filmId, int categoryId)
        {
            var response = iFilmCategoryBusiness.Read(filmId, categoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(FilmCategoryViewModel model)
        {
            var response = iFilmCategoryBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int filmId, int categoryId)
        {
            var response = iFilmCategoryBusiness.Read(filmId, categoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int filmId, int categoryId)
        {
            var response = iFilmCategoryBusiness.Delete(filmId, categoryId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { filmId, categoryId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iFilmCategoryBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}