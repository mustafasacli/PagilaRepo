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
    public class StoreController : OzelYurtBaseController
    {
        private IStoreBusiness iStoreBusiness;

        public StoreController(IStoreBusiness iStoreBusiness = null)
        {
            this.iStoreBusiness = iStoreBusiness ??
                GsbIoC.Instance.GetInstance<IStoreBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iStoreBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new StoreViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(StoreViewModel model)
        {
            var response = iStoreBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int storeId)
        {
            var response = iStoreBusiness.Read(storeId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int storeId)
        {
            var response = iStoreBusiness.Read(storeId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(StoreViewModel model)
        {
            var response = iStoreBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int storeId)
        {
            var response = iStoreBusiness.Read(storeId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int storeId)
        {
            var response = iStoreBusiness.Delete(storeId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { storeId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iStoreBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}