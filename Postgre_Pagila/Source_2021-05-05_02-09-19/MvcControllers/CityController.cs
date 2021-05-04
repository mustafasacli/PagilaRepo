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
    public class CityController : OzelYurtBaseController
    {
        private ICityBusiness iCityBusiness;

        public CityController(ICityBusiness iCityBusiness = null)
        {
            this.iCityBusiness = iCityBusiness ??
                GsbIoC.Instance.GetInstance<ICityBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iCityBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new CityViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(CityViewModel model)
        {
            var response = iCityBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int cityId)
        {
            var response = iCityBusiness.Read(cityId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int cityId)
        {
            var response = iCityBusiness.Read(cityId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(CityViewModel model)
        {
            var response = iCityBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int cityId)
        {
            var response = iCityBusiness.Read(cityId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int cityId)
        {
            var response = iCityBusiness.Delete(cityId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { cityId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iCityBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}