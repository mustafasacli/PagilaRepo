
using Pagila.ViewModel;using SI.CommandBus.Core;using SI.QueryBus.Core;


using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class InventoryController : PagilaBaseController
    {
        private IInventoryBusiness iInventoryBusiness;
        private ICommandBus commandBus;
        private IQueryBus queryBus;

        public InventoryController(IInventoryBusiness iInventoryBusiness = null, ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
            this.iInventoryBusiness = iInventoryBusiness ??
                GsbIoC.Instance.GetInstance<IInventoryBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iInventoryBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new InventoryViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(InventoryViewModel model)
        {
            var response = iInventoryBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int inventoryId)
        {
            var response = iInventoryBusiness.Read(inventoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int inventoryId)
        {
            var response = iInventoryBusiness.Read(inventoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(InventoryViewModel model)
        {
            var response = iInventoryBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int inventoryId)
        {
            var response = iInventoryBusiness.Read(inventoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int inventoryId)
        {
            var response = iInventoryBusiness.Delete(inventoryId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { inventoryId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iInventoryBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}