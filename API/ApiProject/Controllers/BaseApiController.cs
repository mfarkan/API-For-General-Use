﻿using Generic.API.Core.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProject.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private ILogger logger;
        public BaseApiController(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
