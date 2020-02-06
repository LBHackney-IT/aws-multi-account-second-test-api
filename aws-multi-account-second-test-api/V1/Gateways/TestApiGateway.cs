using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace aws_multi_account_second_test_api.V1.Gateways
{
//gateway to call the existing Test API for the AWS Multi Account testing 
    public class TestApiGateway
    {

        public HttpResponseMessage getDataFromTestApi()
        {
            //http client
            var client = new HttpClient();
            if (Environment.GetEnvironmentVariable("header-name") != null)
            {
                client.DefaultRequestHeaders.Add(Environment.GetEnvironmentVariable("header-name"),
                   Environment.GetEnvironmentVariable("header-value"));
            }
            var result = client.GetAsync(Environment.GetEnvironmentVariable("test_api_url")).Result;
            return result;
        }
    }
}
