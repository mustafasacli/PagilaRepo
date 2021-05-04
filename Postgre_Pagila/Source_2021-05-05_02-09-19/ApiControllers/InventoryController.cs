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
    public class InventoryController : ApiController
    {
        private IInventoryBusiness iInventoryBusiness;

        public InventoryController(IInventoryBusiness iInventoryBusiness = null)
        {
            this.iInventoryBusiness = iInventoryBusiness ?? 
                GsbIoC.Instance.GetInstance<IInventoryBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(InventoryViewModel model)
        {
            var response = new SimpleResponse<InventoryViewModel>();
            response = iInventoryBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int inventoryId)
        {
            var modelResult = iInventoryBusiness.Read(inventoryId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(InventoryViewModel model)
        {
            var response = new SimpleResponse();
            response = iInventoryBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int inventoryId)
        {
            var result = iInventoryBusiness.Delete(inventoryId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iInventoryBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}