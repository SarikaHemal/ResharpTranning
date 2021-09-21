using ResharpTranning.Base;
using ResharpTranning.Model;
using ResharpTranning.Utilities;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace ResharpTranning.Steps
{
    [Binding]
    public class PostProfileFeatureSteps
    {
        private Settings _settings;
        public PostProfileFeatureSteps(Settings settings)
        {
            _settings = settings;
        }
        [Given(@"I perform POST operation for ""(.*)"" with body")]
        [Obsolete]
        public void GivenIPerformPOSTOperationForWithBody(string Uri, Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _settings.Request = new RestRequest(Uri, Method.POST);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(new { name = data.name });
            _settings.Request.AddUrlSegment("profileNo", Convert.ToInt32(data.profile));
            _settings.Response = _settings.RestClient.ExecuteAsyncRequest<Posts>(_settings.Request).GetAwaiter().GetResult();

        }


    }
}
