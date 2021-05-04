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
    public class CountryController : ControllerBase
    {
        private ICountryBusiness iCountryBusiness;

        public CountryController(ICountryBusiness iCountryBusiness)
        {
            this.iCountryBusiness = iCountryBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iCountryBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new CountryViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(CountryViewModel model)
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
        public IActionResult Detail(int countryId)
        {
            var response = iCountryBusiness.Read(countryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int countryId)
        {
            var response = iCountryBusiness.Read(countryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(CountryViewModel model)
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

        public IActionResult Delete(int countryId)
        {
            var response = iCountryBusiness.Read(countryId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int countryId)
        {
            var response = iCountryBusiness.Delete(countryId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { countryId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iCountryBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}