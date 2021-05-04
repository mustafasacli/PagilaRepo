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
    public class StoreController : ControllerBase
    {
        private IStoreBusiness iStoreBusiness;

        public StoreController(IStoreBusiness iStoreBusiness)
        {
            this.iStoreBusiness = iStoreBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iStoreBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new StoreViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(StoreViewModel model)
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
        public IActionResult Detail(int storeId)
        {
            var response = iStoreBusiness.Read(storeId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int storeId)
        {
            var response = iStoreBusiness.Read(storeId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(StoreViewModel model)
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

        public IActionResult Delete(int storeId)
        {
            var response = iStoreBusiness.Read(storeId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int storeId)
        {
            var response = iStoreBusiness.Delete(storeId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { storeId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iStoreBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}