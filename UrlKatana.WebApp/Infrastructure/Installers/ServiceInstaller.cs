using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UrlKatana.Business.Services;

namespace UrlKatana.WebApp.Infrastructure.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("UrlKatana.Business")
                             .BasedOn(typeof(IService))                
                             .WithService.AllInterfaces()
                             .LifestyleTransient());
        }
    }
}