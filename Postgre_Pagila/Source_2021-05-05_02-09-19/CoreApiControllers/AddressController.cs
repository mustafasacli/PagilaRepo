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
    public class AddressController : ControllerBase
    {
        private IAddressBusiness iAddressBusiness;
        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger,
                    IAddressBusiness iAddressBusiness)
        {
            this._logger = logger;
            this.iAddressBusiness = iAddressBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<AddressViewModel> Create(AddressViewModel model)
        {
            var response = iAddressBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<AddressViewModel> Detail(int addressId)
        {
            var response = iAddressBusiness.Read(addressId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(AddressViewModel model)
        {
            var response = iAddressBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int addressId)
        {
            var result = iAddressBusiness.Delete(addressId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<AddressViewModel>> ReadAll()
        {
            var response = iAddressBusiness.ReadAll();
            return response;
        }
    }
}