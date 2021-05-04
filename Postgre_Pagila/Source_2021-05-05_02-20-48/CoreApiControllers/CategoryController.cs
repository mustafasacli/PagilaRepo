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
    public class CategoryController : ControllerBase
    {
        private ICategoryBusiness iCategoryBusiness;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger,
                    ICategoryBusiness iCategoryBusiness)
        {
            this._logger = logger;
            this.iCategoryBusiness = iCategoryBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<CategoryViewModel> Create(CategoryViewModel model)
        {
            var response = iCategoryBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<CategoryViewModel> Detail(int categoryId)
        {
            var response = iCategoryBusiness.Read(categoryId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(CategoryViewModel model)
        {
            var response = iCategoryBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int categoryId)
        {
            var result = iCategoryBusiness.Delete(categoryId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<CategoryViewModel>> ReadAll()
        {
            var response = iCategoryBusiness.ReadAll();
            return response;
        }
    }
}