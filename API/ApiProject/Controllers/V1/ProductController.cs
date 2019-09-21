using Generic.API.Core.Logger;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProject.Controllers.V1
{
    [Authorize]
    [ApiVersion("2.0")]
    public class ProductController : BaseApiController
    {
        private ILogger logger;
        public ProductController(ILogger logger) : base(logger)
        {
            this.logger = logger;
        }
        public string Get(int id)
        {
            return "Product 1";
        }
    }
}
