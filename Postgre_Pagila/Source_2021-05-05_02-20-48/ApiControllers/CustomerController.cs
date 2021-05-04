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
    public class CustomerController : ApiController
    {
        private ICustomerBusiness iCustomerBusiness;

        public CustomerController(ICustomerBusiness iCustomerBusiness = null)
        {
            this.iCustomerBusiness = iCustomerBusiness ?? 
                GsbIoC.Instance.GetInstance<ICustomerBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(CustomerViewModel model)
        {
            var response = new SimpleResponse<CustomerViewModel>();
            response = iCustomerBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int customerId)
        {
            var modelResult = iCustomerBusiness.Read(customerId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(CustomerViewModel model)
        {
            var response = new SimpleResponse();
            response = iCustomerBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int customerId)
        {
            var result = iCustomerBusiness.Delete(customerId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iCustomerBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}