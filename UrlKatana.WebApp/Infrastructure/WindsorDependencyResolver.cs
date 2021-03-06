﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace UrlKatana.WebApp.Infrastructure
{
    internal sealed class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        public object GetService(Type t)
        {
            return container.Kernel.HasComponent(t)
                 ? container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return container.ResolveAll(t).Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(container);
        }

        public void Dispose()
        {

        }
    }

}