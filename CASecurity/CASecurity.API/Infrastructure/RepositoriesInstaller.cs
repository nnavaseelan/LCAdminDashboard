using CASecurity.API.Repository;
using CASecurity.API.Service;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;


namespace CASecurity.API.Infrastructure
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            //container.Register(Component.For(typeof(IRepository))
            //                            .ImplementedBy((typeof(CASecurity.API.Repository.Repository)))
            //                            .LifestylePerWebRequest());

            container.Register(Component.For<ICAService>()
                                        .ImplementedBy<CAService>()
                                        .LifestylePerWebRequest());




        }
    }
}