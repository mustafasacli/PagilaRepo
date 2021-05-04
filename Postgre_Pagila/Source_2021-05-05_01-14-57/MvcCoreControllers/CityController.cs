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
    public class CityController : ControllerBase
    {
        private ICityBusiness iCityBusiness;

        public CityController(ICityBusiness iCityBusiness)
        {
            this.iCityBusiness = iCityBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iCityBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new CityViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(CityViewModel model)
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
        public IActionResult Detail(int cityId)
        {
            var response = iCityBusiness.Read(cityId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int cityId)
        {
            var response = iCityBusiness.Read(cityId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(CityViewModel model)
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

        public IActionResult Delete(int cityId)
        {
            var response = iCityBusiness.Read(cityId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int cityId)
        {
            var response = iCityBusiness.Delete(cityId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { cityId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iCityBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}