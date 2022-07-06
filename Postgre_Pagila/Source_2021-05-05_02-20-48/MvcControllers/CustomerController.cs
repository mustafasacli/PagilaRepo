using Pagila.Command.Base.Result;
using Pagila.Command.Customer;
using Pagila.Query.Customer;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using SimpleInfra.Validation;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class CustomerController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public CustomerController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<CustomerReadAllQuery, CustomerList>(new CustomerReadAllQuery());
            return View(response.Data.Customers);
        }

        public ActionResult Create()
        {
            var model = new CustomerViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(CustomerViewModel model)
        {
            EntityValidationResult validationResult = model.Validate();
            if (validationResult.HasError)
            {
                ModelState.AddModelError(string.Empty, validationResult.AllValidationMessages);
                return View(nameof(Create), model);
            }
            var command = GetCommandFromViewModel<CustomerInsertCommand, CustomerViewModel>(model);
            var response = commandBus.Send<CustomerInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int customerId)
        {
            var response = queryBus.Send<CustomerReadByIdQuery, CustomerResult>(new CustomerReadByIdQuery { Id = customerId });

            if (response.Data?.Customer == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Customer);
        }

        public ActionResult Edit(int customerId)
        {
            var response = queryBus.Send<CustomerReadByIdQuery, CustomerResult>(new CustomerReadByIdQuery { Id = customerId });

            if (response.Data?.Customer == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Customer);
        }

        [HttpPost]
        public ActionResult UpdatePost(CustomerViewModel model)
        {
            EntityValidationResult validationResult = model.Validate();
            if (validationResult.HasError)
            {
                ModelState.AddModelError(string.Empty, validationResult.AllValidationMessages);
                return View(nameof(Create), model);
            }
            var command = GetCommandFromViewModel<CustomerUpdateCommand, CustomerViewModel>(model);
            var response = commandBus.Send<CustomerUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int CustomerId)
        {
            var response = queryBus.Send<CustomerReadByIdQuery, CustomerResult>(new CustomerReadByIdQuery { Id = CustomerId });

            if (response.Data?.Customer == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Customer);
        }

        [HttpPost]
        public ActionResult DeletePost(int? CustomerId)
        {
            var response = commandBus.Send<CustomerDeleteCommand, LongCommandResult>(new CustomerDeleteCommand { Id = CustomerId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { CustomerId });
            }
        }

        [HttpGet]
        public JsonResult ReadAll()
        {
            var response = queryBus.Send<CustomerReadAllQuery, CustomerList>(CustomerReadAllQuery.GetEmptyInstance());
            return JsonResponse(response.Data.Customers);
        }
    }
}