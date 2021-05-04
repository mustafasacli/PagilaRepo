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
    public class CustomerController : ControllerBase
    {
        private ICustomerBusiness iCustomerBusiness;

        public CustomerController(ICustomerBusiness iCustomerBusiness)
        {
            this.iCustomerBusiness = iCustomerBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iCustomerBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new CustomerViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(CustomerViewModel model)
        {
            var response = iCustomerBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public IActionResult Detail(int customerId)
        {
            var response = iCustomerBusiness.Read(customerId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int customerId)
        {
            var response = iCustomerBusiness.Read(customerId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(CustomerViewModel model)
        {
            var response = iCustomerBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public IActionResult Delete(int customerId)
        {
            var response = iCustomerBusiness.Read(customerId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int customerId)
        {
            var response = iCustomerBusiness.Delete(customerId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { customerId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iCustomerBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}