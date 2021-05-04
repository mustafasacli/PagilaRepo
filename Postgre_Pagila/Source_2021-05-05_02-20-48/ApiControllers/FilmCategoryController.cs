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
    public class FilmCategoryController : ApiController
    {
        private IFilmCategoryBusiness iFilmCategoryBusiness;

        public FilmCategoryController(IFilmCategoryBusiness iFilmCategoryBusiness = null)
        {
            this.iFilmCategoryBusiness = iFilmCategoryBusiness ?? 
                GsbIoC.Instance.GetInstance<IFilmCategoryBusiness>();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(FilmCategoryViewModel model)
        {
            var response = new SimpleResponse<FilmCategoryViewModel>();
            response = iFilmCategoryBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int filmId, int categoryId)
        {
            var modelResult = iFilmCategoryBusiness.Read(filmId, categoryId);
            return Json(modelResult);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(FilmCategoryViewModel model)
        {
            var response = new SimpleResponse();
            response = iFilmCategoryBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int filmId, int categoryId)
        {
            var result = iFilmCategoryBusiness.Delete(filmId, categoryId);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iFilmCategoryBusiness.ReadAll();
            return Json(modelResult);
        }
    }
}