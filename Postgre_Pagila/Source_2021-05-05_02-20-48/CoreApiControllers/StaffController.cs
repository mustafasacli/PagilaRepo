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
    public class StaffController : ControllerBase
    {
        private IStaffBusiness iStaffBusiness;
        private readonly ILogger<StaffController> _logger;

        public StaffController(ILogger<StaffController> logger,
                    IStaffBusiness iStaffBusiness)
        {
            this._logger = logger;
            this.iStaffBusiness = iStaffBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<StaffViewModel> Create(StaffViewModel model)
        {
            var response = iStaffBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<StaffViewModel> Detail(int staffId)
        {
            var response = iStaffBusiness.Read(staffId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(StaffViewModel model)
        {
            var response = iStaffBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int staffId)
        {
            var result = iStaffBusiness.Delete(staffId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<StaffViewModel>> ReadAll()
        {
            var response = iStaffBusiness.ReadAll();
            return response;
        }
    }
}