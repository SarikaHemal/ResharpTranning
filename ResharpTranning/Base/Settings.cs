﻿using ResharpTranning.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResharpTranning.Base
{
    public class Settings
    {
        public Uri BaseUri{get;set;}
        public IRestResponse<Posts> Response { get; set; }
        public IRestRequest Request { get; set; }
        public RestClient RestClient { get; set; } = new RestClient();

    }
}
