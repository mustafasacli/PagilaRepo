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
    public class PaymentController : ControllerBase
    {
        private IPaymentBusiness iPaymentBusiness;

        public PaymentController(IPaymentBusiness iPaymentBusiness)
        {
            this.iPaymentBusiness = iPaymentBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iPaymentBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new PaymentViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(PaymentViewModel model)
        {
            var response = iPaymentBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iPaymentBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}