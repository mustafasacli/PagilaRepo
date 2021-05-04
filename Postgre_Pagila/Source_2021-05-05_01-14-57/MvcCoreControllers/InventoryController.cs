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
    public class InventoryController : ControllerBase
    {
        private IInventoryBusiness iInventoryBusiness;

        public InventoryController(IInventoryBusiness iInventoryBusiness)
        {
            this.iInventoryBusiness = iInventoryBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iInventoryBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new InventoryViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(InventoryViewModel model)
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
        public IActionResult Detail(int inventoryId)
        {
            var response = iInventoryBusiness.Read(inventoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int inventoryId)
        {
            var response = iInventoryBusiness.Read(inventoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(InventoryViewModel model)
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

        public IActionResult Delete(int inventoryId)
        {
            var response = iInventoryBusiness.Read(inventoryId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int inventoryId)
        {
            var response = iInventoryBusiness.Delete(inventoryId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { inventoryId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iInventoryBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}