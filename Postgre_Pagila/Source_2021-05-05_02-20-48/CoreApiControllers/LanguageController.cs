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
    public class LanguageController : ControllerBase
    {
        private ILanguageBusiness iLanguageBusiness;
        private readonly ILogger<LanguageController> _logger;

        public LanguageController(ILogger<LanguageController> logger,
                    ILanguageBusiness iLanguageBusiness)
        {
            this._logger = logger;
            this.iLanguageBusiness = iLanguageBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<LanguageViewModel> Create(LanguageViewModel model)
        {
            var response = iLanguageBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<LanguageViewModel> Detail(int languageId)
        {
            var response = iLanguageBusiness.Read(languageId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(LanguageViewModel model)
        {
            var response = iLanguageBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int languageId)
        {
            var result = iLanguageBusiness.Delete(languageId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<LanguageViewModel>> ReadAll()
        {
            var response = iLanguageBusiness.ReadAll();
            return response;
        }
    }
}