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
    public class CountryController : OzelYurtBaseController
    {
        private ICountryBusiness iCountryBusiness;

        public CountryController(ICountryBusiness iCountryBusiness = null)
        {
            this.iCountryBusiness = iCountryBusiness ??
                GsbIoC.Instance.GetInstance<ICountryBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iCountryBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new CountryViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(CountryViewModel model)
        {
            var response = iCountryBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int countryId)
        {
            var response = iCountryBusiness.Read(countryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int countryId)
        {
            var response = iCountryBusiness.Read(countryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(CountryViewModel model)
        {
            var response = iCountryBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int countryId)
        {
            var response = iCountryBusiness.Read(countryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int countryId)
        {
            var response = iCountryBusiness.Delete(countryId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { countryId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iCountryBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}