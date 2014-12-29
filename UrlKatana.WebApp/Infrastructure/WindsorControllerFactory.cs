﻿using System.Web.Mvc;
using Castle.Windsor;

namespace UrlKatana.WebApp.Infrastructure
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            if (controllerType == null)
                return null;

            return container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            container.Release(controller);
        }
    }
}