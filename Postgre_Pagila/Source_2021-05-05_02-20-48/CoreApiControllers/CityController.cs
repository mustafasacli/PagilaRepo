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
    public class CityController : ControllerBase
    {
        private ICityBusiness iCityBusiness;
        private readonly ILogger<CityController> _logger;

        public CityController(ILogger<CityController> logger,
                    ICityBusiness iCityBusiness)
        {
            this._logger = logger;
            this.iCityBusiness = iCityBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<CityViewModel> Create(CityViewModel model)
        {
            var response = iCityBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<CityViewModel> Detail(int cityId)
        {
            var response = iCityBusiness.Read(cityId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(CityViewModel model)
        {
            var response = iCityBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int cityId)
        {
            var result = iCityBusiness.Delete(cityId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<CityViewModel>> ReadAll()
        {
            var response = iCityBusiness.ReadAll();
            return response;
        }
    }
}