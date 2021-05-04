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
    public class PaymentController : OzelYurtBaseController
    {
        private IPaymentBusiness iPaymentBusiness;

        public PaymentController(IPaymentBusiness iPaymentBusiness = null)
        {
            this.iPaymentBusiness = iPaymentBusiness ??
                GsbIoC.Instance.GetInstance<IPaymentBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iPaymentBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new PaymentViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(PaymentViewModel model)
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
        public ActionResult ReadAll()
        {
            var response = iPaymentBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}