
using Pagila.ViewModel;using SI.CommandBus.Core;using SI.QueryBus.Core;


using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class CustomerController : PagilaBaseController
    {
        private ICustomerBusiness iCustomerBusiness;
        private ICommandBus commandBus;
        private IQueryBus queryBus;

        public CustomerController(ICustomerBusiness iCustomerBusiness = null, ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
            this.iCustomerBusiness = iCustomerBusiness ??
                GsbIoC.Instance.GetInstance<ICustomerBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iCustomerBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new CustomerViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(CustomerViewModel model)
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
        public ActionResult Detail(int customerId)
        {
            var response = iCustomerBusiness.Read(customerId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int customerId)
        {
            var response = iCustomerBusiness.Read(customerId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(CustomerViewModel model)
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

        public ActionResult Delete(int customerId)
        {
            var response = iCustomerBusiness.Read(customerId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int customerId)
        {
            var response = iCustomerBusiness.Delete(customerId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { customerId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iCustomerBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}