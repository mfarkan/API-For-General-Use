﻿using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace ApiProject.Infrastructure
{
    public class ControllerRoot : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;

        public ControllerRoot(IWindsorContainer container)
        {
            this._container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller =
            (IHttpController)this._container.Resolve(controllerType);

            request.RegisterForDispose(
             new Release(
                 () => this._container.Release(controller)));

            return controller;
        }
    }
    public class Release : IDisposable
    {
        private readonly Action _release;
        public Release(Action release)
        {
            this._release = release;
        }
        public void Dispose()
        {
            this._release();
        }
    }
}