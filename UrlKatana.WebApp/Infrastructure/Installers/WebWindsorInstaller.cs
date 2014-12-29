using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UrlKatana.Business.Services;
using System.Web.Http;

namespace UrlKatana.WebApp.Infrastructure.Installers
{
    public class WebWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes
                .FromAssembly(typeof(WindsorApplication).Assembly)
                .BasedOn<ApiController>()
                .LifestyleScoped());

            container.Register(Classes
                .FromAssembly(typeof(WindsorApplication).Assembly)
                .BasedOn<IController>()
                .LifestylePerWebRequest());
        }
    }
}