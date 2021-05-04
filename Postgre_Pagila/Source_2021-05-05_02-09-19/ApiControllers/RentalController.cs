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
    public class RentalController : ApiController
    {
        private IRentalBusiness iRentalBusiness;

        public RentalController(IRentalBusiness iRentalBusiness = null)
        {
            this.iRentalBusiness = iRentalBusiness ?? 
                GsbIoC.Instance.GetInstance<IRentalBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(RentalViewModel model)
        {
            var response = new SimpleResponse<RentalViewModel>();
            response = iRentalBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int rentalId)
        {
            var modelResult = iRentalBusiness.Read(rentalId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(RentalViewModel model)
        {
            var response = new SimpleResponse();
            response = iRentalBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int rentalId)
        {
            var result = iRentalBusiness.Delete(rentalId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iRentalBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}