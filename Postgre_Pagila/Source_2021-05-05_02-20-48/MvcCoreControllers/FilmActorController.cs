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
    public class FilmActorController : ControllerBase
    {
        private IFilmActorBusiness iFilmActorBusiness;

        public FilmActorController(IFilmActorBusiness iFilmActorBusiness)
        {
            this.iFilmActorBusiness = iFilmActorBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iFilmActorBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new FilmActorViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(FilmActorViewModel model)
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
        public IActionResult Detail(int actorId, int filmId)
        {
            var response = iFilmActorBusiness.Read(actorId, filmId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int actorId, int filmId)
        {
            var response = iFilmActorBusiness.Read(actorId, filmId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(FilmActorViewModel model)
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

        public IActionResult Delete(int actorId, int filmId)
        {
            var response = iFilmActorBusiness.Read(actorId, filmId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int actorId, int filmId)
        {
            var response = iFilmActorBusiness.Delete(actorId, filmId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { actorId, filmId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iFilmActorBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}