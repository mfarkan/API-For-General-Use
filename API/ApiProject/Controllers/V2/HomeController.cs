﻿using Generic.API.Core.Logger;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProject.Controllers.V2
{
    [Authorize]
    [ApiVersion("2.0")]
    public class HomeController : BaseApiController
    {
        private ILogger _logger;
        public HomeController(ILogger logger) : base(logger)
        {
            this._logger = logger;
        }
        public IEnumerable<string> Get()
        {

            return new string[] { "value2.0", "value3.0" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
