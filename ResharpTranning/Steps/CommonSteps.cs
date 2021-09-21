using ResharpTranning.Base;
using ResharpTranning.Utilities;
using RestSharp;
using RestSharp.Authenticators;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ResharpTranning.Steps
{
    [Binding]
    public class CommonSteps
    {
        private Settings _settings;
        public CommonSteps(Settings settings)
        {
            _settings = settings;
        }
        [Given(@"I perform authinetication of user with following detail")]
        [Obsolete]
        public void GivenIPerformAuthineticationOfUserWithFollowingDetail(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _settings.Request = new RestRequest("auth/login", Method.POST);
            //_settings.Request.RequestFormat = DataFormat.Json;
           
            _settings.Request.AddJsonBody(new { email =(string)data.email, password = (string)data.password });

            //get access token
            _settings.Response = _settings.RestClient.ExecuteTaskAsync(_settings.Request).GetAwaiter().GetResult();
            var access_token = _settings.Response.GetResponseObject("access_token");

            //authentication
            var jwtAuth = new JwtAuthenticator(access_token);
            _settings.RestClient.Authenticator = jwtAuth;

        }
    }
}
