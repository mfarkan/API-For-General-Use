using System;
using System.Configuration;
using API.Test.TokenTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace API.Test.TokenTest
{
    [TestClass]
    public class TokenTest
    {
        public TokenTest()
        {
            string baseAPIUrl = ConfigurationManager.AppSettings["baseAPIUrl"];
            client = new RestClient(baseAPIUrl);
        }
        private RestClient client;
        [TestMethod]
        public void Autharization_Endpoint_Is_Alive()
        {
            var request = new RestRequest("/token", Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            IRestResponse response = client.Execute(request);

            AliveResponse aliveResponse = JsonConvert.DeserializeObject<AliveResponse>(response.Content);


            Assert.AreEqual("unsupported_grant_type", aliveResponse.error);
        }
        [TestMethod]
        public void Autharization_Endpoint_Return_Access_Token()
        {
            var accessToken = getAuthToken();
            Assert.IsNotNull(accessToken);
        }
        protected string getAuthToken()
        {
            RestRequest request = new RestRequest("/token", Method.POST);

            request.Parameters.Clear();
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            request.AddParameter("grant_type", "password");
            request.AddParameter("username", "Your_User");
            request.AddParameter("password", "123456");

            IRestResponse response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<AccessToken>(response.Content);

            return content.access_token;

        }
    }
}
