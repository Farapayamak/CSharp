// You can add RestClient.cs manually or use our nuget package
// https://www.nuget.org/packages/Farapayamak.RestClient

namespace FaraPayamak
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClient restClient = new RestClient("username", "password");
            //restClient.SendSMS("09123456789", "5000xxx", "test sms");
            string credit = restClient.GetCredit().Value;
            var result = restClient.BaseServiceNumber("test sms", "09123456789", 5555);

            // SOAP samples are inside the QuickStart folder
        }
    }
}
