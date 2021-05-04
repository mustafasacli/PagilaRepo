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
    public class ActorController : ControllerBase
    {
        private IActorBusiness iActorBusiness;
        private readonly ILogger<ActorController> _logger;

        public ActorController(ILogger<ActorController> logger,
                    IActorBusiness iActorBusiness)
        {
            this._logger = logger;
            this.iActorBusiness = iActorBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<ActorViewModel> Create(ActorViewModel model)
        {
            var response = iActorBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<ActorViewModel> Detail(int actorId)
        {
            var response = iActorBusiness.Read(actorId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(ActorViewModel model)
        {
            var response = iActorBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int actorId)
        {
            var result = iActorBusiness.Delete(actorId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<ActorViewModel>> ReadAll()
        {
            var response = iActorBusiness.ReadAll();
            return response;
        }
    }
}