
using Pagila.ViewModel;using SI.CommandBus.Core;using SI.QueryBus.Core;


using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class CategoryController : PagilaBaseController
    {
        private ICategoryBusiness iCategoryBusiness;
        private ICommandBus commandBus;
        private IQueryBus queryBus;

        public CategoryController(ICategoryBusiness iCategoryBusiness = null, ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
            this.iCategoryBusiness = iCategoryBusiness ??
                GsbIoC.Instance.GetInstance<ICategoryBusiness>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iCategoryBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new CategoryViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(CategoryViewModel model)
        {
            var response = iCategoryBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int categoryId)
        {
            var response = iCategoryBusiness.Read(categoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int categoryId)
        {
            var response = iCategoryBusiness.Read(categoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(CategoryViewModel model)
        {
            var response = iCategoryBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int categoryId)
        {
            var response = iCategoryBusiness.Read(categoryId);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data);
        }

        [HttpPost]
        public ActionResult DeletePost(int categoryId)
        {
            var response = iCategoryBusiness.Delete(categoryId);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { categoryId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iCategoryBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}