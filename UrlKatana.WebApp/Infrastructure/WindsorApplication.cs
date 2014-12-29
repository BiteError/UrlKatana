using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace UrlKatana.WebApp.Infrastructure
{
    public abstract class WindsorApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected IWindsorContainer Container
        {
            get { return container; }
            set { container = value; }
        }

        protected WindsorApplication()
        {

        }


        protected void Application_Start(object sender, EventArgs e)
        {
            Initialise();
        }

        protected virtual void Initialise()
        {
            Container = CreateContainer();
            RunInstallers();
            AppStart();
        }

        protected abstract void AppStart();

        protected virtual void RunInstallers()
        {
            Container.Install(FromAssembly.This());
        }

        protected virtual IWindsorContainer CreateContainer()
        {
            return new WindsorContainer();
        }
    }
}