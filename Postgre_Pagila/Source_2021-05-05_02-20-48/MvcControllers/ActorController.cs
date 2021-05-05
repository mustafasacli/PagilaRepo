
using Pagila.Query.Actor;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class ActorController : PagilaBaseController
    {
        private IActorBusiness iActorBusiness;
        private ICommandBus commandBus;
        private IQueryBus queryBus;

        public ActorController(IActorBusiness iActorBusiness = null, ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
            this.iActorBusiness = iActorBusiness ??
                GsbIoC.Instance.GetInstance<IActorBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<ActorReadAllQuery, ActorList>(new ActorReadAllQuery());
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new ActorViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(ActorViewModel model)
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
        public ActionResult Detail(int actorId)
        {
            var response = iActorBusiness.Read(actorId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int actorId)
        {
            var response = iActorBusiness.Read(actorId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(ActorViewModel model)
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

        public ActionResult Delete(int actorId)
        {
            var response = iActorBusiness.Read(actorId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int actorId)
        {
            var response = iActorBusiness.Delete(actorId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { actorId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iActorBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}