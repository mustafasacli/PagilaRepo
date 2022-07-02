using Pagila.Command.Base.Result;
using Pagila.Command.Payment;
using Pagila.Query.Payment;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class PaymentController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public PaymentController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<PaymentReadAllQuery, PaymentList>(new PaymentReadAllQuery());
            return View(response.Data.Payments);
        }

        public ActionResult Create()
        {
            var model = new PaymentViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(PaymentViewModel model)
        {
            var command = GetCommandFromViewModel<PaymentInsertCommand, PaymentViewModel>(model);
            var response = commandBus.Send<PaymentInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? PaymentId)
        {
            var response = queryBus.Send<PaymentReadByIdQuery, PaymentResult>(new PaymentReadByIdQuery { Id = PaymentId });

            if (response.Data?.Payment == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Payment);
        }

        public ActionResult Edit(int PaymentId)
        {
            var response = queryBus.Send<PaymentReadByIdQuery, PaymentResult>(new PaymentReadByIdQuery { Id = PaymentId });

            if (response.Data?.Payment == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Payment);
        }

        [HttpPost]
        public ActionResult UpdatePost(PaymentViewModel model)
        {
            var command = GetCommandFromViewModel<PaymentUpdateCommand, PaymentViewModel>(model);
            var response = commandBus.Send<PaymentUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int PaymentId)
        {
            var response = queryBus.Send<PaymentReadByIdQuery, PaymentResult>(new PaymentReadByIdQuery { Id = PaymentId });

            if (response.Data?.Payment == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Payment);
        }

        [HttpPost]
        public ActionResult DeletePost(int? PaymentId)
        {
            var response = commandBus.Send<PaymentDeleteCommand, LongCommandResult>(new PaymentDeleteCommand { Id = PaymentId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { PaymentId });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = queryBus.Send<PaymentReadAllQuery, PaymentList>(PaymentReadAllQuery.GetEmptyInstance());
            return Json(response.Data.Payments, JsonRequestBehavior.AllowGet);
        }
    }
}