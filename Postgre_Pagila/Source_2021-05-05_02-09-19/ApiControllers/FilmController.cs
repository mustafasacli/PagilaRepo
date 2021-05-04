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
    public class FilmController : ApiController
    {
        private IFilmBusiness iFilmBusiness;

        public FilmController(IFilmBusiness iFilmBusiness = null)
        {
            this.iFilmBusiness = iFilmBusiness ?? 
                GsbIoC.Instance.GetInstance<IFilmBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(FilmViewModel model)
        {
            var response = new SimpleResponse<FilmViewModel>();
            response = iFilmBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int filmId)
        {
            var modelResult = iFilmBusiness.Read(filmId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(FilmViewModel model)
        {
            var response = new SimpleResponse();
            response = iFilmBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int filmId)
        {
            var result = iFilmBusiness.Delete(filmId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iFilmBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}