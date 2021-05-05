
using Pagila.ViewModel;using SI.CommandBus.Core;using SI.QueryBus.Core;


using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class AddressController : PagilaBaseController
    {
        private IAddressBusiness iAddressBusiness;
        private ICommandBus commandBus;
        private IQueryBus queryBus;

        public AddressController(IAddressBusiness iAddressBusiness = null, ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
            this.iAddressBusiness = iAddressBusiness ??
                GsbIoC.Instance.GetInstance<IAddressBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iAddressBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new AddressViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(AddressViewModel model)
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
        public ActionResult Detail(int addressId)
        {
            var response = iAddressBusiness.Read(addressId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int addressId)
        {
            var response = iAddressBusiness.Read(addressId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(AddressViewModel model)
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

        public ActionResult Delete(int addressId)
        {
            var response = iAddressBusiness.Read(addressId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int addressId)
        {
            var response = iAddressBusiness.Delete(addressId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { addressId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iAddressBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}