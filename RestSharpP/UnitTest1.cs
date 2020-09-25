using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace RestSharpP
{
    [TestClass]
    public class UnitTest1
    {
        //ExecuteJSON_Server server = new ExecuteJSON_Server();
        [TestMethod]
        public void TestNameJob()
        {
            var client = new RestClient("http://localhost:3000/");
            var name = new RestRequest("users?userId=1", Method.GET);
            var res = client.Execute(name);

            //name.AddUrlSegment("{rno}", "1");
            //var res = server.ExecuteServer(name);
            //var content = new JsonDeserializer();
            JObject output = JObject.Parse(res.Content); // content.Deserialize<Dictionary<string, string>>(res);
        }
    }
}
