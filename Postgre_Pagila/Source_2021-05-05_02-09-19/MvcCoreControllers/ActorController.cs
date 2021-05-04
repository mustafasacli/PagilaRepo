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
    public class ActorController : ControllerBase
    {
        private IActorBusiness iActorBusiness;

        public ActorController(IActorBusiness iActorBusiness)
        {
            this.iActorBusiness = iActorBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iActorBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new ActorViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(ActorViewModel model)
        {
            var response = iActorBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public IActionResult Detail(int actorId)
        {
            var response = iActorBusiness.Read(actorId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int actorId)
        {
            var response = iActorBusiness.Read(actorId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(ActorViewModel model)
        {
            var response = iActorBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public IActionResult Delete(int actorId)
        {
            var response = iActorBusiness.Read(actorId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int actorId)
        {
            var response = iActorBusiness.Delete(actorId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { actorId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iActorBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}