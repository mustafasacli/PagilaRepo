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
    public class RentalController : ControllerBase
    {
        private IRentalBusiness iRentalBusiness;

        public RentalController(IRentalBusiness iRentalBusiness)
        {
            this.iRentalBusiness = iRentalBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iRentalBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new RentalViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(RentalViewModel model)
        {
            var response = iRentalBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public IActionResult Detail(int rentalId)
        {
            var response = iRentalBusiness.Read(rentalId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int rentalId)
        {
            var response = iRentalBusiness.Read(rentalId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(RentalViewModel model)
        {
            var response = iRentalBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public IActionResult Delete(int rentalId)
        {
            var response = iRentalBusiness.Read(rentalId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int rentalId)
        {
            var response = iRentalBusiness.Delete(rentalId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { rentalId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iRentalBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}