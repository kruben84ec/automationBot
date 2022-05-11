using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestApiconnect
{
    class Program
    {
        static async Task Main(string[] args)
        {

     

            var json = JsonConvert.SerializeObject();
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://dceservice-qa-restapi.onbmc.com/api/jwt/login";
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

    }
}
