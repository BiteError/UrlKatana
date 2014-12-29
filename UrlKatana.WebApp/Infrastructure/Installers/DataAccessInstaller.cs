using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UrlKatana.Business.Services;
using UrlKatana.Business.Services.DataAccess;

namespace UrlKatana.WebApp.Infrastructure.Installers
{
    public class DataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IConnectionProvider)).ImplementedBy(typeof(SqlLiteConnectionProvider)).LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyNamed("UrlKatana.Business")
                             .BasedOn(typeof(IRepository<>))                
                             .WithService.AllInterfaces()
                             .LifestyleTransient());
        }
    }
}