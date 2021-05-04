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
    public class CustomerController : ControllerBase
    {
        private ICustomerBusiness iCustomerBusiness;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger,
                    ICustomerBusiness iCustomerBusiness)
        {
            this._logger = logger;
            this.iCustomerBusiness = iCustomerBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<CustomerViewModel> Create(CustomerViewModel model)
        {
            var response = iCustomerBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<CustomerViewModel> Detail(int customerId)
        {
            var response = iCustomerBusiness.Read(customerId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(CustomerViewModel model)
        {
            var response = iCustomerBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int customerId)
        {
            var result = iCustomerBusiness.Delete(customerId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<CustomerViewModel>> ReadAll()
        {
            var response = iCustomerBusiness.ReadAll();
            return response;
        }
    }
}