using SI.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Routing;

namespace Pagila.WebUI.Helpers
{
    internal static class RequestExtensionHelper
    {
        /// <summary>
        /// Gets controller name from request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static string GetControllerName(this HttpRequestBase request)
        {
            var ctrl = string.Empty;

            try
            {
                var routeValues = request.RequestContext?.RouteData?.Values;

                if (routeValues != null && routeValues.ContainsKey("controller"))
                    ctrl = (string)routeValues["controller"] ?? string.Empty;
            }
            catch (Exception e)
            { SimpleCommonLogger.DayLogger?.Error(e); }

            return ctrl;
        }

        //
        /// <summary>
        /// Gets action name from request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static string GetActionName(this HttpRequestBase request)
        {
            var action = string.Empty;

            try
            {
                var routeValues = request?.RequestContext?.RouteData?.Values;

                if (routeValues != null && routeValues.ContainsKey("action"))
                    action = (string)routeValues["action"] ?? string.Empty;
            }
            catch (Exception e)
            { SimpleCommonLogger.DayLogger?.Error(e); }

            return action;
        }

        /// <summary>
        /// Gets area name from request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static string GetAreaName(this HttpRequestBase request)
        {
            var area_name = string.Empty;

            try
            {
                var dataTokens = request?.RequestContext?.RouteData?.DataTokens;

                if (dataTokens != null && dataTokens.ContainsKey("area"))
                    area_name = (string)dataTokens["area"] ?? string.Empty;
            }
            catch (Exception e)
            { SimpleCommonLogger.DayLogger?.Error(e); }

            return area_name;
        }

        /// <summary>
        /// Gets full Url of Request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static string GetUrl(this HttpRequestBase request)
        {
            var url = request?.Url?.ToString() ?? string.Empty;
            return url;
        }

        /// <summary>
        /// gets Key Value Dictionary of Routedata object.
        /// </summary>
        /// <param name="routeData"></param>
        /// <returns></returns>
        internal static Dictionary<string, string> GetKeyValues(this RouteData routeData)
        {
            var dictionary = new Dictionary<string, string>();

            foreach (KeyValuePair<string, object> item in routeData.Values)
            {
                dictionary[item.Key] = item.Value?.ToString() ?? string.Empty;
            }

            return dictionary;
        }

        internal static string GetRequestAddress(this HttpRequestBase request)
        {
            string ip = string.Empty;

            try
            {
                string ipAdress = request?.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(ipAdress))
                {
                    string[] ipAdresses = ipAdress.Split(',');
                    if (ipAdresses.Length != 0)
                    {
                        ip = ipAdresses[0];
                    }
                }

                if (string.IsNullOrEmpty(ip))
                {
                    ip = request?.ServerVariables["REMOTE_ADDR"];
                }

                if (string.IsNullOrEmpty(ip))
                {
                    /// ip = ((HttpContextBase)Request.Properties["MS_HttpContext"]).Request.UserHostAddress;
                    ip = request?.UserHostAddress;///GetClientIp();
                }
            }
            catch (Exception e)
            { SimpleCommonLogger.DayLogger?.LogError(e); }

            return ip ?? string.Empty;
        }

        internal static string GetRequestMachineName(this HttpRequestBase request)
        {
            string s = string.Empty;

            try
            {
                s = request.UserHostName;

                if (string.IsNullOrEmpty(s))
                {
                    s = Dns.GetHostEntry(request.GetRequestAddress()).HostName;
                }
            }
            catch (Exception e)
            { SimpleCommonLogger.DayLogger?.LogError(e); }

            return s;
        }

        /// <summary>
        /// Get Absolute Uri
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static string GetAbsoluteUri(this HttpRequestBase request)
        {
            var url = request?.Url?.AbsoluteUri ?? string.Empty;

            return url;
        }

        internal static string GetIPFromDNS()
        {
            string ipAdress = string.Empty;

            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                ipAdress =
                    host.AddressList
                    .FirstOrDefault(q => q.AddressFamily == AddressFamily.InterNetwork)?.ToString() ?? string.Empty;
            }
            catch (Exception e)
            {
                SimpleCommonLogger.DayLogger?.LogError(e);
            }

            return ipAdress;
        }

        internal static string GetRequestBody(this HttpRequestBase httpRequest)
        {
            string json = "";

            try
            {
                Stream req = httpRequest.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                json = new StreamReader(req).ReadToEnd();
            }
            catch (Exception ex)
            {
                SimpleCommonLogger.DayLogger?.LogError(ex);
            }

            return json;
        }

        /// <summary>
        /// Gets controller name from request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static string GetControllerName(this HttpRequest request)
        {
            var ctrl = string.Empty;

            try
            {
                var routeValues = request.RequestContext?.RouteData?.Values;

                if (routeValues != null && routeValues.ContainsKey("controller"))
                    ctrl = (string)routeValues["controller"] ?? string.Empty;
            }
            catch (Exception e)
            { SimpleCommonLogger.DayLogger?.Error(e); }

            return ctrl;
        }

        //
        /// <summary>
        /// Gets action name from request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static string GetActionName(this HttpRequest request)
        {
            var action = string.Empty;

            try
            {
                var routeValues = request?.RequestContext?.RouteData?.Values;

                if (routeValues != null && routeValues.ContainsKey("action"))
                    action = (string)routeValues["action"] ?? string.Empty;
            }
            catch (Exception e)
            { SimpleCommonLogger.DayLogger?.Error(e); }

            return action;
        }

        /// <summary>
        /// Gets area name from request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static string GetAreaName(this HttpRequest request)
        {
            var area_name = string.Empty;

            try
            {
                var dataTokens = request?.RequestContext?.RouteData?.DataTokens;

                if (dataTokens != null && dataTokens.ContainsKey("area"))
                    area_name = (string)dataTokens["area"] ?? string.Empty;
            }
            catch (Exception e)
            { SimpleCommonLogger.DayLogger?.Error(e); }

            return area_name;
        }

        /// <summary>
        /// Gets full Url of Request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static string GetUrl(this HttpRequest request)
        {
            var url = request?.Url?.ToString() ?? string.Empty;
            return url;
        }

        internal static string GetRequestAddress(this HttpRequest request)
        {
            string ip = string.Empty;

            try
            {
                string ipAdress = request?.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(ipAdress))
                {
                    string[] ipAdresses = ipAdress.Split(',');
                    if (ipAdresses.Length != 0)
                    {
                        ip = ipAdresses[0];
                    }
                }

                if (string.IsNullOrEmpty(ip))
                {
                    ip = request?.ServerVariables["REMOTE_ADDR"];
                }

                if (string.IsNullOrEmpty(ip))
                {
                    /// ip = ((HttpContextBase)Request.Properties["MS_HttpContext"]).Request.UserHostAddress;
                    ip = request?.UserHostAddress;///GetClientIp();
                }
            }
            catch (Exception e)
            { SimpleCommonLogger.DayLogger?.LogError(e); }

            return ip ?? string.Empty;
        }

        internal static string GetRequestMachineName(this HttpRequest request)
        {
            string s = string.Empty;

            try
            {
                s = request.UserHostName;

                if (string.IsNullOrEmpty(s))
                {
                    s = Dns.GetHostEntry(request.GetRequestAddress()).HostName;
                }
            }
            catch (Exception e)
            { SimpleCommonLogger.DayLogger?.LogError(e); }

            return s;
        }

        internal static string GetRequestBody(this HttpRequest httpRequest)
        {
            string json = "";

            try
            {
                Stream req = httpRequest.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                json = new StreamReader(req).ReadToEnd();
            }
            catch (Exception ex)
            {
                SimpleCommonLogger.DayLogger?.LogError(ex);
            }

            return json;
        }
    }
}