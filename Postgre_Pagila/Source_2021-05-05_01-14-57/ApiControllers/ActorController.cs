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
    public class ActorController : ApiController
    {
        private IActorBusiness iActorBusiness;

        public ActorController(IActorBusiness iActorBusiness = null)
        {
            this.iActorBusiness = iActorBusiness ?? 
                GsbIoC.Instance.GetInstance<IActorBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(ActorViewModel model)
        {
            var response = new SimpleResponse<ActorViewModel>();
            response = iActorBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int actorId)
        {
            var modelResult = iActorBusiness.Read(actorId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(ActorViewModel model)
        {
            var response = new SimpleResponse();
            response = iActorBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int actorId)
        {
            var result = iActorBusiness.Delete(actorId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iActorBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}