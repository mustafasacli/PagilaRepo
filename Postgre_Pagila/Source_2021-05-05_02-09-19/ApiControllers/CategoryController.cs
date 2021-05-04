using Pagila.ViewModel;
using Pagila.Business.Interfaces;
using Pagila.Dtos;
using SimpleInfra.Common.Response;
using SimpleInfra.Common.Core;
using Gsb.IoC;
using SimpleInfra.Validation;
using SimpleInfra.Mapping;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Pagila.Web.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryBusiness iCategoryBusiness;

        public CategoryController(ICategoryBusiness iCategoryBusiness = null)
        {
            this.iCategoryBusiness = iCategoryBusiness ?? 
                GsbIoC.Instance.GetInstance<ICategoryBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(CategoryViewModel model)
        {
            var response = new SimpleResponse<CategoryViewModel>();
            response = iCategoryBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int categoryId)
        {
            var modelResult = iCategoryBusiness.Read(categoryId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(CategoryViewModel model)
        {
            var response = new SimpleResponse();
            response = iCategoryBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int categoryId)
        {
            var result = iCategoryBusiness.Delete(categoryId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iCategoryBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}