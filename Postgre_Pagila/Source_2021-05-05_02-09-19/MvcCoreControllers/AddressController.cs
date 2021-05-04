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
    public class AddressController : ControllerBase
    {
        private IAddressBusiness iAddressBusiness;

        public AddressController(IAddressBusiness iAddressBusiness)
        {
            this.iAddressBusiness = iAddressBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iAddressBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new AddressViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(AddressViewModel model)
        {
            var response = iAddressBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public IActionResult Detail(int addressId)
        {
            var response = iAddressBusiness.Read(addressId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int addressId)
        {
            var response = iAddressBusiness.Read(addressId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(AddressViewModel model)
        {
            var response = iAddressBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public IActionResult Delete(int addressId)
        {
            var response = iAddressBusiness.Read(addressId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int addressId)
        {
            var response = iAddressBusiness.Delete(addressId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { addressId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iAddressBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}