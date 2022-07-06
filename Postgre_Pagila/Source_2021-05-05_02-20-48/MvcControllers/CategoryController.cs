using Pagila.Command.Base.Result;
using Pagila.Command.Category;
using Pagila.Query.Category;
using Pagila.ViewModel;
using SI.CommandBus.Core;
using SI.QueryBus.Core;
using SimpleInfra.Validation;
using System.Net;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public class CategoryController : PagilaBaseController
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public CategoryController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = queryBus.Send<CategoryReadAllQuery, CategoryList>(new CategoryReadAllQuery());
            return View(response.Data.Categories);
        }

        public ActionResult Create()
        {
            var model = new CategoryViewModel();
            return View(nameof(Create), model);
        }

        [HttpPost]
        public ActionResult CreatePost(CategoryViewModel model)
        {
            EntityValidationResult validationResult = model.Validate();
            if (validationResult.HasError)
            {
                ModelState.AddModelError(string.Empty, validationResult.AllValidationMessages);
                return View(nameof(Create), model);
            }
            var command = GetCommandFromViewModel<CategoryInsertCommand, CategoryViewModel>(model);
            var response = commandBus.Send<CategoryInsertCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Create), model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? CategoryId)
        {
            var response = queryBus.Send<CategoryReadByIdQuery, CategoryResult>(new CategoryReadByIdQuery { Id = CategoryId });

            if (response.Data?.Category == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data.Category);
        }

        public ActionResult Edit(int CategoryId)
        {
            var response = queryBus.Send<CategoryReadByIdQuery, CategoryResult>(new CategoryReadByIdQuery { Id = CategoryId });

            if (response.Data?.Category == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Edit), response.Data.Category);
        }

        [HttpPost]
        public ActionResult UpdatePost(CategoryViewModel model)
        {
            EntityValidationResult validationResult = model.Validate();
            if (validationResult.HasError)
            {
                ModelState.AddModelError(string.Empty, validationResult.AllValidationMessages);
                return View(nameof(Create), model);
            }
            var command = GetCommandFromViewModel<CategoryUpdateCommand, CategoryViewModel>(model);
            var response = commandBus.Send<CategoryUpdateCommand, LongCommandResult>(command);

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View(nameof(Edit), model);
            }
        }

        public ActionResult Delete(int CategoryId)
        {
            var response = queryBus.Send<CategoryReadByIdQuery, CategoryResult>(new CategoryReadByIdQuery { Id = CategoryId });

            if (response.Data?.Category == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(nameof(Delete), response.Data.Category);
        }

        [HttpPost]
        public ActionResult DeletePost(int? CategoryId)
        {
            var response = commandBus.Send<CategoryDeleteCommand, LongCommandResult>(new CategoryDeleteCommand { Id = CategoryId });

            if (response.ResponseCode > 0)
            { return RedirectToAction(nameof(Index)); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction(nameof(Delete), new { CategoryId });
            }
        }

        [HttpGet]
        public JsonResult ReadAll()
        {
            var response = queryBus.Send<CategoryReadAllQuery, CategoryList>(CategoryReadAllQuery.GetEmptyInstance());
            return JsonResponse(response.Data.Categories);
        }
    }
}