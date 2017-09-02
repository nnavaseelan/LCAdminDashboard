using CASecurity.Domain.Migrations;
using CASecurity.Web.Infrastructure;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CASecurity.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WindsorWrapper();
        }
        private static void WindsorWrapper()
        {
            WindsorContainerWrapper.Container = new WindsorContainer();

            WindsorContainerWrapper.Container.Register(Component.For<ApplicationDbContext>().LifeStyle.PerWebRequest);

            WindsorContainerWrapper.Container.Install(new LoggerInstaller(),
                                                    new RepositoriesInstaller(),
                                                    new ControllersInstaller());

            var controllerFactory = new WindsorControllerFactory(WindsorContainerWrapper.Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

        }
    }
}
