using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
namespace RestSharpP
{
    class ExecuteJSON_Server
    {
        RestClient client = new RestClient("http://localhost:3000/");
        //Uri url = new Uri("http://localhost:3000");
        public IRestResponse ExecuteServer(RestRequest request) 
        {
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
