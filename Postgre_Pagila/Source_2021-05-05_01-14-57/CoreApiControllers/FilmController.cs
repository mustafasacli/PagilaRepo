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
    public class FilmController : ControllerBase
    {
        private IFilmBusiness iFilmBusiness;
        private readonly ILogger<FilmController> _logger;

        public FilmController(ILogger<FilmController> logger,
                    IFilmBusiness iFilmBusiness)
        {
            this._logger = logger;
            this.iFilmBusiness = iFilmBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<FilmViewModel> Create(FilmViewModel model)
        {
            var response = iFilmBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<FilmViewModel> Detail(int filmId)
        {
            var response = iFilmBusiness.Read(filmId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(FilmViewModel model)
        {
            var response = iFilmBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int filmId)
        {
            var result = iFilmBusiness.Delete(filmId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<FilmViewModel>> ReadAll()
        {
            var response = iFilmBusiness.ReadAll();
            return response;
        }
    }
}