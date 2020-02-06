using aws_multi_account_second_test_api.V1.Gateways;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aws_multi_account_second_test_api.V1.Controllers 
{
    [ApiVersion("1.0")]
    [Route("api/v1/fakeCall")]
    [ApiController]
    [Produces("application/json")]
    public class FakeCallController : Controller
    {

        [HttpGet]
        [Route("test-api-call")]
        [ProducesResponseType(typeof(Dictionary<string, bool>), 200)]
        public IActionResult HealthCheck()
        {
            var gateway = new TestApiGateway();
            var result = gateway.getDataFromTestApi();
            var json = Json(JsonConvert.DeserializeObject<JObject>(result.Content.ReadAsStringAsync().Result));

            json.StatusCode = (int)result.StatusCode;
            json.ContentType = "application/json";
            return json;
        }
    }
}
