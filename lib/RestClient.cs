using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace FaraPayamak
{
    class RestClient
    {
        private readonly string Endpoint = "https://rest.payamak-panel.com/api/SendSMS/";
        private string Username { get; set; }
        private string Password { get; set; }

     
        public RestClient(string username, string password)
        {
            Username = username;
            Password = password;
        }


        private RestResponse Request(string operation, Dictionary<string, string> values)
        {
            values.Add("username", Username);
            values.Add("password", Password);

            using (var client = new WebClient())
            {
                var response = client.UploadValues(Endpoint + operation, values.Aggregate(new NameValueCollection(),
                (seed, current) => {
                    seed.Add(current.Key, current.Value);
                    return seed;
                }));

                return JsonConvert.DeserializeObject<RestResponse>(Encoding.Default.GetString(response));
            }
        }


        public RestResponse SendSMS(string to, string from, string text, bool isFlash = false)
        {
            string operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
            return Request(operation, new Dictionary<string, string>
                { { "to", to }, { "from", from }, { "text", text }, { "isFlash", isFlash.ToString() } });
        }

        public RestResponse GetDeliveries2(long recId)
        {
            string operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
            return Request(operation, new Dictionary<string, string> { { "recID", recId.ToString() } });
        }

        public RestResponse GetMessages(int location, string from, int index, int count)
        {
            string operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
            return Request(operation, new Dictionary<string, string>{ 
                { "location", location.ToString() }, {"from", from }, {"index", index.ToString() }, {"count", count.ToString() } 
            });
        }

        public RestResponse GetCredit()
        {
            string operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
            return Request(operation, new Dictionary<string, string>());
        }

        public RestResponse GetBasePrice()
        {
            string operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
            return Request(operation, new Dictionary<string, string>());
        }

        public RestResponse GetUserNumbers()
        {
            string operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
            return Request(operation, new Dictionary<string, string>());
        }

        public RestResponse BaseServiceNumber(string text, string to, int bodyId)
        {
            string operation = System.Reflection.MethodBase.GetCurrentMethod().Name;
            return Request(operation, new Dictionary<string, string> { 
                { "text", text }, { "to", to }, { "bodyId", bodyId.ToString() } 
            });
        }

    }



    

    public class RestResponse
    {
        public string Value { get; set; }
        public int RetStatus { get; set; }
        public string StrRetStatus { get; set; }
    }
}
