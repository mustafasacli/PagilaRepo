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
    public class LanguageController : ApiController
    {
        private ILanguageBusiness iLanguageBusiness;

        public LanguageController(ILanguageBusiness iLanguageBusiness = null)
        {
            this.iLanguageBusiness = iLanguageBusiness ?? 
                GsbIoC.Instance.GetInstance<ILanguageBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(LanguageViewModel model)
        {
            var response = new SimpleResponse<LanguageViewModel>();
            response = iLanguageBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int languageId)
        {
            var modelResult = iLanguageBusiness.Read(languageId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(LanguageViewModel model)
        {
            var response = new SimpleResponse();
            response = iLanguageBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int languageId)
        {
            var result = iLanguageBusiness.Delete(languageId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iLanguageBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}