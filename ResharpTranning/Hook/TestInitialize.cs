using ResharpTranning.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ResharpTranning.Hook
{
    [Binding]
    public class TestInitialize
    {
        private Settings _settings;
        public TestInitialize(Settings settings)
        {
            _settings = settings;
        }
        [BeforeScenario]
        public void TestSetUp()
        {
            _settings.BaseUri = new Uri(ConfigurationManager.AppSettings["baseUri"].ToString());
            _settings.RestClient.BaseUrl = _settings.BaseUri;
        }

    }
}
