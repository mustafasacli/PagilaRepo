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
    public class InventoryController : ControllerBase
    {
        private IInventoryBusiness iInventoryBusiness;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger,
                    IInventoryBusiness iInventoryBusiness)
        {
            this._logger = logger;
            this.iInventoryBusiness = iInventoryBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<InventoryViewModel> Create(InventoryViewModel model)
        {
            var response = iInventoryBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<InventoryViewModel> Detail(int inventoryId)
        {
            var response = iInventoryBusiness.Read(inventoryId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(InventoryViewModel model)
        {
            var response = iInventoryBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int inventoryId)
        {
            var result = iInventoryBusiness.Delete(inventoryId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<InventoryViewModel>> ReadAll()
        {
            var response = iInventoryBusiness.ReadAll();
            return response;
        }
    }
}