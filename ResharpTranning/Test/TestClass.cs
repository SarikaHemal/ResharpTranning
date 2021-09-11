using Newtonsoft.Json.Linq;
using NUnit.Framework;
using ResharpTranning.Model;
using ResharpTranning.Utilities;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResharpTranning.Test
{   
    [TestFixture]
    class TestClass
    {
        [Test]
        public void TestMethod1()
        {
            var client = new RestClient(" http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);
            var response = client.Execute(request);
            var result=response.DeserializeResponse()["author"];
            int statusCode = (int)response.StatusCode;
            Console.WriteLine("Status Code: " + statusCode);

            //var deserialize = new JsonDeserializer();
            //var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            // String result = output["id"];
            
            //JObject obj = JObject.Parse(response.Content);
            Console.WriteLine(result);
            Assert.That(result, Is.EqualTo("Karthik KK"), "Author is not correct");
        }
        [Test]
        [Obsolete]
        public void PostWithAnnonysBody()
        {
            IRestClient client = new RestClient("http://localhost:3000/");
            IRestRequest request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Posts(){ id = "17", title = "Sarika", author = "Sarika" });

            //costom extension method
            var response = client.ExecuteTaskAsync<Posts>(request).GetAwaiter().GetResult();
            /*Console.WriteLine("Status code:  " + (int)response.StatusCode);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);*/
            //var result = output["author"];
            
            Console.WriteLine(response.Data.author);
            Assert.That(response.Data.author, Is.EqualTo("Sarika"), "Title is not match");

        }
    }
}
