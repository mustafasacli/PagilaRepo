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
    public class StaffController : ApiController
    {
        private IStaffBusiness iStaffBusiness;

        public StaffController(IStaffBusiness iStaffBusiness = null)
        {
            this.iStaffBusiness = iStaffBusiness ?? 
                GsbIoC.Instance.GetInstance<IStaffBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(StaffViewModel model)
        {
            var response = new SimpleResponse<StaffViewModel>();
            response = iStaffBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int staffId)
        {
            var modelResult = iStaffBusiness.Read(staffId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(StaffViewModel model)
        {
            var response = new SimpleResponse();
            response = iStaffBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int staffId)
        {
            var result = iStaffBusiness.Delete(staffId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iStaffBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}