using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace ApiProject.App_Start
{
    /// <summary>
    /// Swagger dökümanında Authorization için statik olarak oluşmasını sağlıyoruz ve parametrelerini ekliyoruz.
    /// </summary>
    public class SwaggerAuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token", new PathItem
            {
                post = new Operation
                {
                    tags = new List<string> { "Authorization" },
                    consumes = new List<string>
                {
                    "application/x-www-form-urlencoded"
                },
                    parameters = new List<Parameter> {
                    new Parameter
                    {
                        type = "string",
                        name = "grant_type",
                        required = true,
                        @in = "formData"
                    },
                    new Parameter
                    {
                        type = "string",
                        name = "username",
                        required = true,
                        @in = "formData"
                    },
                    new Parameter
                    {
                        type = "string",
                        name = "password",
                        required = true,
                        @in = "formData"
                    }
                }
                }
            });
        }
    }
}