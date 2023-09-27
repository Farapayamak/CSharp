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
        private readonly string Endpoint_Smart = "https://rest.payamak-panel.com/api/SmartSMS/";
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

            string endpoint = operation.Contains("SmartSMS") ? Endpoint.Replace("SendSMS/", "") : Endpoint;
            using (var client = new WebClient())
            {
                var response = client.UploadValues(endpoint + operation, values.Aggregate(new NameValueCollection(),
                (seed, current) => {
                    seed.Add(current.Key, current.Value);
                    return seed;
                }));

                return JsonConvert.DeserializeObject<RestResponse>(Encoding.Default.GetString(response));
            }
        }

        
        private string RequestAsJson(string operation, Dictionary<string, object> values)
        {
            values.Add("username", Username);
            values.Add("password", Password);

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                var data = JsonConvert.SerializeObject(values);
                var response = client.UploadString(Endpoint_Smart + operation, data);

                return response;
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



        public RestResponse SendSmartSMS(string to, string text, string from, string fromSupportOne, string fromSupportTwo)
        {
            string operation = "SmartSMS/Send";
            return Request(operation, new Dictionary<string, string> {
                { "to", to }, { "text", text }, { "from", from }, { "fromSupportOne", fromSupportOne }, { "fromSupportTwo", fromSupportTwo }
            });
        }

        public RestSmartResponse SendMultipleSmartSMS(string[] to, string[] text, string from, string fromSupportOne, string fromSupportTwo)
        {
            string operation = "SendMultiple";
            var result = RequestAsJson(operation, new Dictionary<string, object> {
                { "to", to }, { "text", text }, { "from", from }, { "fromSupportOne", fromSupportOne }, { "fromSupportTwo", fromSupportTwo }
            });
            return JsonConvert.DeserializeObject<RestSmartResponse>(result);
        }

        public RestResponse GetSmartDeliveries2(long id)
        {
            string operation = "SmartSMS/GetDeliveries2";
            return Request(operation, new Dictionary<string, string> {
                { "Id", id.ToString() }
            });
        }

        public RestResponse GetSmartDeliveries(long[] ids)
        {
            string operation = "GetDeliveries";
            var result = RequestAsJson(operation, new Dictionary<string, object> {
                { "Ids", ids }
            });
            return JsonConvert.DeserializeObject<RestResponse>(result);
        }

    }





    public class RestResponse
    {
        public string Value { get; set; }
        public int RetStatus { get; set; }
        public string StrRetStatus { get; set; }
    }


    public class RestSmartResponse
    {
        public string ReqStatus { get; set; }
        public string Message { get; set; }
        public List<RestSmartResult> Result { get; set; }
    }

    public class RestSmartResult
    {
        public string Mobile { get; set; }
        public long ID { get; set; }
    }
}
