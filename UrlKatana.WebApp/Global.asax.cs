using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UrlKatana.WebApp.Infrastructure;

namespace UrlKatana.WebApp
{
    public class WebApiApplication : WindsorApplication
    {
        protected override void AppStart()
        {
            WireUpDependencyResolvers();

            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
        private void WireUpDependencyResolvers()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(Container);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container));
        }
    }
}
