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
    public class FilmActorController : ControllerBase
    {
        private IFilmActorBusiness iFilmActorBusiness;
        private readonly ILogger<FilmActorController> _logger;

        public FilmActorController(ILogger<FilmActorController> logger,
                    IFilmActorBusiness iFilmActorBusiness)
        {
            this._logger = logger;
            this.iFilmActorBusiness = iFilmActorBusiness;
        }


        [HttpPost]
        [Route("create")]
        public SimpleResponse<FilmActorViewModel> Create(FilmActorViewModel model)
        {
            var response = iFilmActorBusiness.Create(model);
            return response;
        }

        [HttpGet]
        [Route("detail")]
        public SimpleResponse<FilmActorViewModel> Detail(int actorId, int filmId)
        {
            var response = iFilmActorBusiness.Read(actorId, filmId);
            return response;
        }

        [HttpPost]
        [Route("update")]
        public SimpleResponse Update(FilmActorViewModel model)
        {
            var response = iFilmActorBusiness.Update(model);
            return response;
        }

        [HttpPost]
        [Route("delete")]
        public SimpleResponse Delete(int actorId, int filmId)
        {
            var result = iFilmActorBusiness.Delete(actorId, filmId);
            return result;
        }

        [HttpGet]
        public SimpleResponse<List<FilmActorViewModel>> ReadAll()
        {
            var response = iFilmActorBusiness.ReadAll();
            return response;
        }
    }
}