using Pagila.Business.Interfaces;
using Pagila.Dtos;
using Pagila.ViewModel;
using Microsoft.AspNetCore.Mvc;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Pagila.Web.Controllers
{
    public class FilmCategoryController : ControllerBase
    {
        private IFilmCategoryBusiness iFilmCategoryBusiness;

        public FilmCategoryController(IFilmCategoryBusiness iFilmCategoryBusiness)
        {
            this.iFilmCategoryBusiness = iFilmCategoryBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iFilmCategoryBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new FilmCategoryViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(FilmCategoryViewModel model)
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
        public IActionResult Detail(int filmId, int categoryId)
        {
            var response = iFilmCategoryBusiness.Read(filmId, categoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int filmId, int categoryId)
        {
            var response = iFilmCategoryBusiness.Read(filmId, categoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(FilmCategoryViewModel model)
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

        public IActionResult Delete(int filmId, int categoryId)
        {
            var response = iFilmCategoryBusiness.Read(filmId, categoryId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int filmId, int categoryId)
        {
            var response = iFilmCategoryBusiness.Delete(filmId, categoryId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { filmId, categoryId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iFilmCategoryBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}