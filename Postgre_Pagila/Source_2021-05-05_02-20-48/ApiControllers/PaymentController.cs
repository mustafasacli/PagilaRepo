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
    public class PaymentController : ApiController
    {
        private IPaymentBusiness iPaymentBusiness;

        public PaymentController(IPaymentBusiness iPaymentBusiness = null)
        {
            this.iPaymentBusiness = iPaymentBusiness ?? 
                GsbIoC.Instance.GetInstance<IPaymentBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(PaymentViewModel model)
        {
            var response = new SimpleResponse<PaymentViewModel>();
            response = iPaymentBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iPaymentBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}