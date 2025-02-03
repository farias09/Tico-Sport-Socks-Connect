using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Mvc5;

namespace UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 🚀 Configurar Unity en la Aplicación
            UnityConfig.RegisterTypes(UnityConfig.Container);
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(UnityConfig.Container));
        }
    }
}
