using Pagila.Command.Base.Result;
using Pagila.Command.Country;
using Pagila.Query.Country;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using SimpleInfra.Validation;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class CountryController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public CountryController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<CountryReadAllQuery, CountryList>(new CountryReadAllQuery());
            return View(response.Data.Countries);
        }

        public ActionResult Create()
        {
            var model = new CountryViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(CountryViewModel model)
        {
            EntityValidationResult validationResult = model.Validate();
            if (validationResult.HasError)
            {
                ModelState.AddModelError(string.Empty, validationResult.AllValidationMessages);
                return View(nameof(Create), model);
            }
            var command = GetCommandFromViewModel<CountryInsertCommand, CountryViewModel>(model);
            var response = commandBus.Send<CountryInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? CountryId)
        {
            var response = queryBus.Send<CountryReadByIdQuery, CountryResult>(new CountryReadByIdQuery { Id = CountryId });

            if (response.Data?.Country == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Country);
        }

        public ActionResult Edit(int CountryId)
        {
            var response = queryBus.Send<CountryReadByIdQuery, CountryResult>(new CountryReadByIdQuery { Id = CountryId });

            if (response.Data?.Country == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Country);
        }

        [HttpPost]
        public ActionResult UpdatePost(CountryViewModel model)
        {
            EntityValidationResult validationResult = model.Validate();
            if (validationResult.HasError)
            {
                ModelState.AddModelError(string.Empty, validationResult.AllValidationMessages);
                return View(nameof(Create), model);
            }
            var command = GetCommandFromViewModel<CountryUpdateCommand, CountryViewModel>(model);
            var response = commandBus.Send<CountryUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int CountryId)
        {
            var response = queryBus.Send<CountryReadByIdQuery, CountryResult>(new CountryReadByIdQuery { Id = CountryId });

            if (response.Data?.Country == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Country);
        }

        [HttpPost]
        public ActionResult DeletePost(int? CountryId)
        {
            var response = commandBus.Send<CountryDeleteCommand, LongCommandResult>(new CountryDeleteCommand { Id = CountryId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { CountryId });
            }
        }

        [HttpGet]
        public JsonResult ReadAll()
        {
            var response = queryBus.Send<CountryReadAllQuery, CountryList>(CountryReadAllQuery.GetEmptyInstance());
            return JsonResponse(response.Data.Countries);
        }
    }
}