
using Pagila.ViewModel;using SI.CommandBus.Core;using SI.QueryBus.Core;


using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class StaffController : PagilaBaseController
    {
        private IStaffBusiness iStaffBusiness;
        private ICommandBus commandBus;
        private IQueryBus queryBus;

        public StaffController(IStaffBusiness iStaffBusiness = null, ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
            this.iStaffBusiness = iStaffBusiness ??
                GsbIoC.Instance.GetInstance<IStaffBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iStaffBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new StaffViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(StaffViewModel model)
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
        public ActionResult Detail(int staffId)
        {
            var response = iStaffBusiness.Read(staffId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int staffId)
        {
            var response = iStaffBusiness.Read(staffId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(StaffViewModel model)
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

        public ActionResult Delete(int staffId)
        {
            var response = iStaffBusiness.Read(staffId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int staffId)
        {
            var response = iStaffBusiness.Delete(staffId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { staffId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iStaffBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}