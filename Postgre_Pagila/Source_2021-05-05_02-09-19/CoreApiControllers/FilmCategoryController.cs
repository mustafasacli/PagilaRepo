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
    public class FilmCategoryController : ControllerBase
    {
        private IFilmCategoryBusiness iFilmCategoryBusiness;
        private readonly ILogger<FilmCategoryController> _logger;

        public FilmCategoryController(ILogger<FilmCategoryController> logger,
                    IFilmCategoryBusiness iFilmCategoryBusiness)
        {
            this._logger = logger;
            this.iFilmCategoryBusiness = iFilmCategoryBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<FilmCategoryViewModel> Create(FilmCategoryViewModel model)
        {
            var response = iFilmCategoryBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<FilmCategoryViewModel> Detail(int filmId, int categoryId)
        {
            var response = iFilmCategoryBusiness.Read(filmId, categoryId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(FilmCategoryViewModel model)
        {
            var response = iFilmCategoryBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int filmId, int categoryId)
        {
            var result = iFilmCategoryBusiness.Delete(filmId, categoryId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<FilmCategoryViewModel>> ReadAll()
        {
            var response = iFilmCategoryBusiness.ReadAll();
            return response;
        }
    }
}