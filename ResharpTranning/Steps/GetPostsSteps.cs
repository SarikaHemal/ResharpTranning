using NUnit.Framework;
using ResharpTranning.Base;
using ResharpTranning.Model;
using ResharpTranning.Utilities;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace ResharpTranning.Steps
{
    [Binding]
    public class GetPostsSteps
    {
        private Settings _settings;
        public GetPostsSteps(Settings settings)
        {
            _settings = settings;
        }
        [Given(@"I perform GET operation for ""(.*)""")]
     
        public void GivenIPerformGETOperationFor(string uri)
        {
            _settings.Request = new RestRequest(uri, Method.GET);
        }
        
        [Given(@"I perform operation for post ""(.*)""")]
        [Obsolete]
        public void GivenIPerformOperationForPost(int postId)
        {
            _settings.Request.AddUrlSegment("postid", postId);
            _settings.Response = _settings.RestClient.ExecuteAsyncRequest<Posts>(_settings.Request).GetAwaiter().GetResult();

        }

        [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            Assert.That(_settings.Response.GetResponseObject(key), Is.EqualTo(value), "{key} is not matching");
        }
    }
}
