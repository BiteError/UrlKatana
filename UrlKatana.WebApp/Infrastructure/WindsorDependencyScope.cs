﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace UrlKatana.WebApp.Infrastructure
{
    internal sealed class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer container;
        private readonly IDisposable scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
            scope = container.BeginScope();
        }

        public object GetService(Type t)
        {
            return container.Kernel.HasComponent(t) ? container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return container.ResolveAll(t).Cast<object>().ToArray();
        }

        public void Dispose()
        {
            scope.Dispose();
        }
    }

}