using Gsb.Common.Core;
using Pagila.Business.Interfaces;
using Pagila.Dtos;
using Pagila.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pagila.CoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private IPaymentBusiness iPaymentBusiness;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger,
                    IPaymentBusiness iPaymentBusiness)
        {
            this._logger = logger;
            this.iPaymentBusiness = iPaymentBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<PaymentViewModel> Create(PaymentViewModel model)
        {
            var response = iPaymentBusiness.Create(model);
            return response;
        }

        [HttpGet]
        public SimpleResponse<List<PaymentViewModel>> ReadAll()
        {
            var response = iPaymentBusiness.ReadAll();
            return response;
        }
    }
}