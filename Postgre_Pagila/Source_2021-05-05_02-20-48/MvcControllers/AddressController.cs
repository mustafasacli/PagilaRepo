using Pagila.Command.Address;
using Pagila.Command.Base.Result;
using Pagila.Query.Address;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class AddressController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public AddressController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<AddressReadAllQuery, AddressList>(new AddressReadAllQuery());
            return View(response.Data.Addresses);
        }

        public ActionResult Create()
        {
            var model = new AddressViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(AddressViewModel model)
        {
            var command = GetCommandFromViewModel<AddressInsertCommand, AddressViewModel>(model);
            var response = commandBus.Send<AddressInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? AddressId)
        {
            var response = queryBus.Send<AddressReadByIdQuery, AddressResult>(new AddressReadByIdQuery { Id = AddressId });

            if (response.Data?.Address == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Address);
        }

        public ActionResult Edit(int AddressId)
        {
            var response = queryBus.Send<AddressReadByIdQuery, AddressResult>(new AddressReadByIdQuery { Id = AddressId });

            if (response.Data?.Address == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Address);
        }

        [HttpPost]
        public ActionResult UpdatePost(AddressViewModel model)
        {
            var command = GetCommandFromViewModel<AddressUpdateCommand, AddressViewModel>(model);
            var response = commandBus.Send<AddressUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int AddressId)
        {
            var response = queryBus.Send<AddressReadByIdQuery, AddressResult>(new AddressReadByIdQuery { Id = AddressId });

            if (response.Data?.Address == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Address);
        }

        [HttpPost]
        public ActionResult DeletePost(int? AddressId)
        {
            var response = commandBus.Send<AddressDeleteCommand, LongCommandResult>(new AddressDeleteCommand { Id = AddressId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { AddressId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = queryBus.Send<AddressReadAllQuery, AddressList>(AddressReadAllQuery.GetEmptyInstance());
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}