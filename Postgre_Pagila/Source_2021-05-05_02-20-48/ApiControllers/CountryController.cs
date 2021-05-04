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
    public class CountryController : ApiController
    {
        private ICountryBusiness iCountryBusiness;

        public CountryController(ICountryBusiness iCountryBusiness = null)
        {
            this.iCountryBusiness = iCountryBusiness ?? 
                GsbIoC.Instance.GetInstance<ICountryBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(CountryViewModel model)
        {
            var response = new SimpleResponse<CountryViewModel>();
            response = iCountryBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int countryId)
        {
            var modelResult = iCountryBusiness.Read(countryId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(CountryViewModel model)
        {
            var response = new SimpleResponse();
            response = iCountryBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int countryId)
        {
            var result = iCountryBusiness.Delete(countryId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iCountryBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}