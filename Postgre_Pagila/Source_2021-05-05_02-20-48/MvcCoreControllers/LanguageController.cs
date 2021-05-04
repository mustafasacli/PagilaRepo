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
    public class LanguageController : ControllerBase
    {
        private ILanguageBusiness iLanguageBusiness;

        public LanguageController(ILanguageBusiness iLanguageBusiness)
        {
            this.iLanguageBusiness = iLanguageBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = iLanguageBusiness.ReadAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new LanguageViewModel();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(LanguageViewModel model)
        {
            var response = iLanguageBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public IActionResult Detail(int languageId)
        {
            var response = iLanguageBusiness.Read(languageId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data, JsonRequestBehavior.AllowGet);
        }
        public IActionResult  Edit(int languageId)
        {
            var response = iLanguageBusiness.Read(languageId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(LanguageViewModel model)
        {
            var response = iLanguageBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public IActionResult Delete(int languageId)
        {
            var response = iLanguageBusiness.Read(languageId);
            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int languageId)
        {
            var response = iLanguageBusiness.Delete(languageId);

            if (response.ResponseCode > 0)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { languageId });
            }
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var response = iLanguageBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}