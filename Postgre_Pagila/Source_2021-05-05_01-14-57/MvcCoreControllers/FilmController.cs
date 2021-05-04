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
    public class FilmController : ControllerBase
    {
        private IFilmBusiness iFilmBusiness;

        public FilmController(IFilmBusiness iFilmBusiness)
        {
            this.iFilmBusiness = iFilmBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iFilmBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new FilmViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(FilmViewModel model)
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
        public IActionResult Detail(int filmId)
        {
            var response = iFilmBusiness.Read(filmId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int filmId)
        {
            var response = iFilmBusiness.Read(filmId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(FilmViewModel model)
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

        public IActionResult Delete(int filmId)
        {
            var response = iFilmBusiness.Read(filmId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int filmId)
        {
            var response = iFilmBusiness.Delete(filmId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { filmId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iFilmBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}