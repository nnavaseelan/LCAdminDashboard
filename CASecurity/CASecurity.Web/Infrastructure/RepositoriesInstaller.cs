
using CASecurity.Service;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;


namespace CASecurity.Web.Infrastructure
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            //container.Register(Component.For(typeof(IRepository))
            //                            .ImplementedBy((typeof(CASecurity.Web.Repository.Repository)))
            //                            .LifestylePerWebRequest());

            container.Register(Component.For<ICAService>()
                                        .ImplementedBy<CAService>()
                                        .LifestylePerWebRequest());




        }
    }
}