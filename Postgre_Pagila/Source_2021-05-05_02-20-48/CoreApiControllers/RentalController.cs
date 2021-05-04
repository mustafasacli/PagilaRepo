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
    public class RentalController : ControllerBase
    {
        private IRentalBusiness iRentalBusiness;
        private readonly ILogger<RentalController> _logger;

        public RentalController(ILogger<RentalController> logger,
                    IRentalBusiness iRentalBusiness)
        {
            this._logger = logger;
            this.iRentalBusiness = iRentalBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<RentalViewModel> Create(RentalViewModel model)
        {
            var response = iRentalBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<RentalViewModel> Detail(int rentalId)
        {
            var response = iRentalBusiness.Read(rentalId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(RentalViewModel model)
        {
            var response = iRentalBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int rentalId)
        {
            var result = iRentalBusiness.Delete(rentalId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<RentalViewModel>> ReadAll()
        {
            var response = iRentalBusiness.ReadAll();
            return response;
        }
    }
}