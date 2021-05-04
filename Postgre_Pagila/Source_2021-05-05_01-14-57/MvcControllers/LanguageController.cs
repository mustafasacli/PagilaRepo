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
    public class LanguageController : OzelYurtBaseController
    {
        private ILanguageBusiness iLanguageBusiness;

        public LanguageController(ILanguageBusiness iLanguageBusiness = null)
        {
            this.iLanguageBusiness = iLanguageBusiness ??
                GsbIoC.Instance.GetInstance<ILanguageBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iLanguageBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new LanguageViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(LanguageViewModel model)
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
        public ActionResult Detail(int languageId)
        {
            var response = iLanguageBusiness.Read(languageId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int languageId)
        {
            var response = iLanguageBusiness.Read(languageId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(LanguageViewModel model)
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

        public ActionResult Delete(int languageId)
        {
            var response = iLanguageBusiness.Read(languageId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int languageId)
        {
            var response = iLanguageBusiness.Delete(languageId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { languageId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iLanguageBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}