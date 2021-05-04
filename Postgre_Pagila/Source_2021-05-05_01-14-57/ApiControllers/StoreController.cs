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
    public class StoreController : ApiController
    {
        private IStoreBusiness iStoreBusiness;

        public StoreController(IStoreBusiness iStoreBusiness = null)
        {
            this.iStoreBusiness = iStoreBusiness ?? 
                GsbIoC.Instance.GetInstance<IStoreBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(StoreViewModel model)
        {
            var response = new SimpleResponse<StoreViewModel>();
            response = iStoreBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int storeId)
        {
            var modelResult = iStoreBusiness.Read(storeId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(StoreViewModel model)
        {
            var response = new SimpleResponse();
            response = iStoreBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int storeId)
        {
            var result = iStoreBusiness.Delete(storeId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iStoreBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}