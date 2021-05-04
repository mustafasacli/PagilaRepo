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
    public class StoreController : ControllerBase
    {
        private IStoreBusiness iStoreBusiness;
        private readonly ILogger<StoreController> _logger;

        public StoreController(ILogger<StoreController> logger,
                    IStoreBusiness iStoreBusiness)
        {
            this._logger = logger;
            this.iStoreBusiness = iStoreBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<StoreViewModel> Create(StoreViewModel model)
        {
            var response = iStoreBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<StoreViewModel> Detail(int storeId)
        {
            var response = iStoreBusiness.Read(storeId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(StoreViewModel model)
        {
            var response = iStoreBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int storeId)
        {
            var result = iStoreBusiness.Delete(storeId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<StoreViewModel>> ReadAll()
        {
            var response = iStoreBusiness.ReadAll();
            return response;
        }
    }
}