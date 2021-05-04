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
    public class StaffController : ControllerBase
    {
        private IStaffBusiness iStaffBusiness;

        public StaffController(IStaffBusiness iStaffBusiness)
        {
            this.iStaffBusiness = iStaffBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iStaffBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new StaffViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(StaffViewModel model)
        {
            var response = iStaffBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public IActionResult Detail(int staffId)
        {
            var response = iStaffBusiness.Read(staffId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int staffId)
        {
            var response = iStaffBusiness.Read(staffId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(StaffViewModel model)
        {
            var response = iStaffBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public IActionResult Delete(int staffId)
        {
            var response = iStaffBusiness.Read(staffId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int staffId)
        {
            var response = iStaffBusiness.Delete(staffId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { staffId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iStaffBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}