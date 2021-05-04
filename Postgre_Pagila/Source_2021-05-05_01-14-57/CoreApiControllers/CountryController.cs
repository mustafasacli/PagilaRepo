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
    public class CountryController : ControllerBase
    {
        private ICountryBusiness iCountryBusiness;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ILogger<CountryController> logger,
                    ICountryBusiness iCountryBusiness)
        {
            this._logger = logger;
            this.iCountryBusiness = iCountryBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<CountryViewModel> Create(CountryViewModel model)
        {
            var response = iCountryBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<CountryViewModel> Detail(int countryId)
        {
            var response = iCountryBusiness.Read(countryId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(CountryViewModel model)
        {
            var response = iCountryBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int countryId)
        {
            var result = iCountryBusiness.Delete(countryId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<CountryViewModel>> ReadAll()
        {
            var response = iCountryBusiness.ReadAll();
            return response;
        }
    }
}