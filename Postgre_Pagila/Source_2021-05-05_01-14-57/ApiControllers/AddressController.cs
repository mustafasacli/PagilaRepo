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
    public class AddressController : ApiController
    {
        private IAddressBusiness iAddressBusiness;

        public AddressController(IAddressBusiness iAddressBusiness = null)
        {
            this.iAddressBusiness = iAddressBusiness ?? 
                GsbIoC.Instance.GetInstance<IAddressBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(AddressViewModel model)
        {
            var response = new SimpleResponse<AddressViewModel>();
            response = iAddressBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int addressId)
        {
            var modelResult = iAddressBusiness.Read(addressId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(AddressViewModel model)
        {
            var response = new SimpleResponse();
            response = iAddressBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int addressId)
        {
            var result = iAddressBusiness.Delete(addressId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iAddressBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}