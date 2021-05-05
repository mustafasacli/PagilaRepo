
using Pagila.ViewModel;using SI.CommandBus.Core;using SI.QueryBus.Core;


using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class RentalController : PagilaBaseController
    {
        private IRentalBusiness iRentalBusiness;
        private ICommandBus commandBus;
        private IQueryBus queryBus;

        public RentalController(IRentalBusiness iRentalBusiness = null, ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
            this.iRentalBusiness = iRentalBusiness ??
                GsbIoC.Instance.GetInstance<IRentalBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iRentalBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new RentalViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(RentalViewModel model)
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
        public ActionResult Detail(int rentalId)
        {
            var response = iRentalBusiness.Read(rentalId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int rentalId)
        {
            var response = iRentalBusiness.Read(rentalId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(RentalViewModel model)
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

        public ActionResult Delete(int rentalId)
        {
            var response = iRentalBusiness.Read(rentalId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int rentalId)
        {
            var response = iRentalBusiness.Delete(rentalId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { rentalId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iRentalBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}