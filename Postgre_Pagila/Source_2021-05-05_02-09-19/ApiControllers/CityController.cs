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
    public class CityController : ApiController
    {
        private ICityBusiness iCityBusiness;

        public CityController(ICityBusiness iCityBusiness = null)
        {
            this.iCityBusiness = iCityBusiness ?? 
                GsbIoC.Instance.GetInstance<ICityBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(CityViewModel model)
        {
            var response = new SimpleResponse<CityViewModel>();
            response = iCityBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int cityId)
        {
            var modelResult = iCityBusiness.Read(cityId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(CityViewModel model)
        {
            var response = new SimpleResponse();
            response = iCityBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int cityId)
        {
            var result = iCityBusiness.Delete(cityId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iCityBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}