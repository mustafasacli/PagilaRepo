using SI.CommandBus;
using SI.CommandBus.Core;
using SI.Logging;
using SI.QueryBus;
using SI.QueryBus.Core;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pagila.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapSimpleInjector();
        }

        protected void Application_Error()
        {
            try
            {
                var error = Server.GetLastError();
                if (error != null)
                    SimpleCommonLogger.DayLogger?.Error(error);
            }
            catch (Exception ex)
            { SimpleCommonLogger.DayLogger?.Error(ex); }
        }

        protected void BootstrapSimpleInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();//new AsyncScopedLifestyle();

            try
            {
                container.Register(typeof(ICommandBus), typeof(CommandBus));
                container.Register(typeof(IQueryBus), typeof(QueryBus));
                /*
                var path = AppDomain.CurrentDomain.BaseDirectory;
                if (Directory.Exists(path + "bin\\"))
                    path += "bin\\";

                Logger?.Debug($"Domain Path: {path}");
                var businessFiles = Directory.GetFiles(path, "*.Business.dll") ?? new string[] { };

                foreach (var file in businessFiles)
                {
                    try
                    {
                        var assembly = Assembly.LoadFile(file);
                        var referencedAssemblies = assembly.GetReferencedAssemblies() ?? new AssemblyName[0];
                        referencedAssemblies.ToList().ForEach(a =>
                        {
                            try
                            {
                                Assembly.Load(a);
                            }
                            catch (Exception e2)
                            {
                                Logger?.Error(e2, $"Asemmbly could not be loaded. Assembly: {a.FullName}");
                                throw;
                            }
                        });

                        RegisterAssembly(container, assembly);

                        Logger?.Info($"\"{assembly.FullName}\" is loaded.");
                        // throw new Exception("Sample Exception");
                    }
                    catch (Exception ex)
                    { Logger?.Error(ex, $"File Name: {file}"); }
                }
            */
            }
            catch (Exception ex2)
            { SimpleCommonLogger.DayLogger?.Error(ex2); }
            //container.Verify();
            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
        private void RegisterAssembly(Container container, Assembly assembly)
        {
            var registrations = assembly
                .GetExportedTypes()
                .Where(type => type.IsClass && !type.IsAbstract
                && type.Namespace.Contains(".Business.")
                && !type.Namespace.Contains(".Business.Interfaces."))
                .Select(q => new { service = (q.GetInterfaces() ?? new Type[0]).LastOrDefault(), implementation = q })
                .ToList();

            if (registrations == null || registrations.Count < 1)
                return;

            //var registrations =
            //    from type in assembly.GetExportedTypes()
            //    where type.IsClass && !type.IsAbstract && type.Namespace.EndsWith(".Business")
            //    from service in type.GetInterfaces()
            //    select new { service, implementation = type };

            foreach (var reg in registrations)
            {
                if (reg.service != null)
                    container.Register(reg.service, reg.implementation, Lifestyle.Scoped);
            }
        }
    }
}
