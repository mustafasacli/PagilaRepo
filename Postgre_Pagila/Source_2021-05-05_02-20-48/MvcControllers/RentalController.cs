using Pagila.Command.Base.Result;
using Pagila.Command.Rental;
using Pagila.Query.Rental;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class RentalController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public RentalController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<RentalReadAllQuery, RentalList>(new RentalReadAllQuery());
            return View(response.Data.Rentals);
        }

        public ActionResult Create()
        {
            var model = new RentalViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(RentalViewModel model)
        {
            var command = GetCommandFromViewModel<RentalInsertCommand, RentalViewModel>(model);
            var response = commandBus.Send<RentalInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? RentalId)
        {
            var response = queryBus.Send<RentalReadByIdQuery, RentalResult>(new RentalReadByIdQuery { Id = RentalId });

            if (response.Data?.Rental == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Rental);
        }

        public ActionResult Edit(int RentalId)
        {
            var response = queryBus.Send<RentalReadByIdQuery, RentalResult>(new RentalReadByIdQuery { Id = RentalId });

            if (response.Data?.Rental == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Rental);
        }

        [HttpPost]
        public ActionResult UpdatePost(RentalViewModel model)
        {
            var command = GetCommandFromViewModel<RentalUpdateCommand, RentalViewModel>(model);
            var response = commandBus.Send<RentalUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int RentalId)
        {
            var response = queryBus.Send<RentalReadByIdQuery, RentalResult>(new RentalReadByIdQuery { Id = RentalId });

            if (response.Data?.Rental == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Rental);
        }

        [HttpPost]
        public ActionResult DeletePost(int? RentalId)
        {
            var response = commandBus.Send<RentalDeleteCommand, LongCommandResult>(new RentalDeleteCommand { Id = RentalId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { RentalId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = queryBus.Send<RentalReadAllQuery, RentalList>(RentalReadAllQuery.GetEmptyInstance());
            return Json(response.Data.Rentals, JsonRequestBehavior.AllowGet);
        }
    }
}