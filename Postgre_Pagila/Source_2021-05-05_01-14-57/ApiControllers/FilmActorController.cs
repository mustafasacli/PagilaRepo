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
    public class FilmActorController : ApiController
    {
        private IFilmActorBusiness iFilmActorBusiness;

        public FilmActorController(IFilmActorBusiness iFilmActorBusiness = null)
        {
            this.iFilmActorBusiness = iFilmActorBusiness ?? 
                GsbIoC.Instance.GetInstance<IFilmActorBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(FilmActorViewModel model)
        {
            var response = new SimpleResponse<FilmActorViewModel>();
            response = iFilmActorBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int actorId, int filmId)
        {
            var modelResult = iFilmActorBusiness.Read(actorId, filmId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(FilmActorViewModel model)
        {
            var response = new SimpleResponse();
            response = iFilmActorBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int actorId, int filmId)
        {
            var result = iFilmActorBusiness.Delete(actorId, filmId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iFilmActorBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}