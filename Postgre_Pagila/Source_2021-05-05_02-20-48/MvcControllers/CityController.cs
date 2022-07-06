using Pagila.Command.Base.Result;
using Pagila.Command.City;
using Pagila.Query.City;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using SimpleInfra.Validation;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class CityController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public CityController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<CityReadAllQuery, CityList>(new CityReadAllQuery());
            return View(response.Data.Cities);
        }

        public ActionResult Create()
        {
            var model = new CityViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(CityViewModel model)
        {
            //if (Request.IsAjaxRequest())
            //{ }
                EntityValidationResult validationResult = model.Validate();
            if (validationResult.HasError)
            {
                ModelState.AddModelError(string.Empty, validationResult.AllValidationMessages);
                return View(nameof(Create), model);
            }
            var command = GetCommandFromViewModel<CityInsertCommand, CityViewModel>(model);
            var response = commandBus.Send<CityInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? CityId)
        {
            var response = queryBus.Send<CityReadByIdQuery, CityResult>(new CityReadByIdQuery { Id = CityId });

            if (response.Data?.City == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.City);
        }

        public ActionResult Edit(int CityId)
        {
            var response = queryBus.Send<CityReadByIdQuery, CityResult>(new CityReadByIdQuery { Id = CityId });

            if (response.Data?.City == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.City);
        }

        [HttpPost]
        public ActionResult UpdatePost([Bind(Include = "CityId,City,CountryId")] CityViewModel model)
        {
            EntityValidationResult validationResult = model.Validate();
            if (validationResult.HasError)
            {
                ModelState.AddModelError(string.Empty, validationResult.AllValidationMessages);
                return View(nameof(Create), model);
            }
            var command = GetCommandFromViewModel<CityUpdateCommand, CityViewModel>(model);
            var response = commandBus.Send<CityUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int CityId)
        {
            var response = queryBus.Send<CityReadByIdQuery, CityResult>(new CityReadByIdQuery { Id = CityId });

            if (response.Data?.City == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.City);
        }

        [HttpPost]
        public ActionResult DeletePost(int? CityId)
        {
            var response = commandBus.Send<CityDeleteCommand, LongCommandResult>(new CityDeleteCommand { Id = CityId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { CityId });
            }
        }

        [HttpGet]
        public JsonResult ReadAll()
        {
            var response = queryBus.Send<CityReadAllQuery, CityList>(CityReadAllQuery.GetEmptyInstance());
            return JsonResponse(response.Data.Cities);
        }
    }
}