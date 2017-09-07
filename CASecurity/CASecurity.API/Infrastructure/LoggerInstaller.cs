using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CASecurity.API.Infrastructure
{
    public class LoggerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(fac => fac.UseLog4Net());
            //container.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
        }
    }
}