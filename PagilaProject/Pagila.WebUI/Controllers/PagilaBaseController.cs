using Pagila.WebUI.Helpers;
using SI.Logging;
using SimpleFileLogging.Interfaces;
using SimpleInfra.Mapping;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Pagila.WebUI.Controllers
{
    public abstract class PagilaBaseController : Controller
    {
        protected TCommand GetCommandFromViewModel<TCommand, TViewModel>(TViewModel viewModel)
            where TCommand : class, new()
            where TViewModel : class
        {
            TCommand command = SimpleMapper.Map<TViewModel, TCommand>(viewModel);
            return command;
        }

        /// <summary>
        /// Hata yakalama metodu.
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            // #if DEBUG
            // #else
            if (filterContext.ExceptionHandled)
                return;

            var errorGuid = DateTime.Today.ToString("yyyy_MM_dd-") + Guid.NewGuid().ToString();
            LogError(filterContext.Exception, errorGuid);

            // if the request is AJAX return JSON else view.
            if (IsAjax(filterContext))
            {
                //Because its a exception raised after ajax invocation
                //Lets return Json
                filterContext.Result = new JsonResult()
                {
                    Data = filterContext.Exception.Message + "  ErrorCode: " + errorGuid,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                ViewData["ErrGuid"] = errorGuid;
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Error/Hata.cshtml",
                    ViewData = base.ViewData
                };
            }
            // #endif
        }

        protected void LogError(Exception ex, string guid)
        {
            if (ex == null)
                return;

            var area = Request.GetAreaName();
            var action = Request.GetActionName();
            var controller = Request.GetControllerName();
            var uri = Request.GetAbsoluteUri();
            var body = Request.GetRequestBody();

            ISimpleLogger logger;
            logger = (ex is NullReferenceException) ?
                SimpleCommonLogger.MonthLogger : SimpleCommonLogger.DayLogger;

            // package: EntityFramework
            // using System.Data.Entity.Validation;
            // TODO :  DbEntityValidationException will be handled. DONE.
            List<string> additionalValues = new List<string> {
                $"Guid: {guid}",
                $"Absolute Uri: {uri}",
                $"Request Address: {this.RequestAddress}",
                $"Request Machine Name: {this.RequestMachineName}",
                $"Response Address: {this.ResponseAddress}",
                $"Area: {area}",
                $"Controller: {controller}",
                $"Action: {action}",
                $"Request Body: {body}" };

            //if (ex is DbEntityValidationException)
            //{
            //    List<string> errors = GetValidationErrors(ex as DbEntityValidationException);
            //    additionalValues.AddRange(errors.ToArray());
            //}

            logger?.Error(ex, additionalValues.ToArray());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the request address. </summary>
        ///
        /// <value> The request address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected string RequestAddress
        {
            get
            {
                string address = Request.GetRequestAddress();
                return address;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the name of the request machine. </summary>
        ///
        /// <value> The name of the request machine. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected string RequestMachineName
        {
            get
            {
                var machineName = Request.GetRequestMachineName();
                return machineName;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the response address. </summary>
        ///
        /// <value> The response address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected string ResponseAddress
        {
            get
            {
                string responseAddress = string.Empty;

                try
                {
                    responseAddress = RequestExtensionHelper.GetIPFromDNS();
                }
                catch (Exception e)
                {
                    SimpleCommonLogger.DayLogger?.LogError(e);
                }

                return responseAddress;
            }
        }

        private bool IsAjax(ControllerContext filterContext)
        {
            return IsAjaxRequest(filterContext.HttpContext.Request);
            // filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        private bool IsAjaxRequest(HttpRequestBase httpRequest)
        {
            return httpRequest.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}