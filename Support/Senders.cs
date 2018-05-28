using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Support
{
    public class Senders
    {
        public static string GetTesteById(string url)
        {
            var client = new HttpClient();

            var response = client.GetStringAsync(url).Result;


            return response;
            
        }
    }
}
