using Farapayamak.RestClient;


namespace FaraPayamak
{
    class Program
    {
        static void Main(string[] args)
        {
            // REST methods
            RestClient restClient = new RestClient("username", "password");
            //restClient.SendSMS("09123456789", "5000xxx", "test sms");
            //string credit = restClient.GetCredit().Value;
            //var result = restClient.BaseServiceNumber("test sms", "09123456789", 5555);

            // SOAP methods
            // Note: You need to comment DUPLICATE endpoints in App.config file to use default endpoint configuration like below
            SendServiceReference.SendSoapClient sendService = new SendServiceReference.SendSoapClient();
            sendService.SendSimpleSMS2("username", "password", "09123456789", "5000xxx", "test sms by soap", false);

            ReceiveServiceReference.ReceiveSoapClient receiveService = new ReceiveServiceReference.ReceiveSoapClient();
            UsersServiceReference.UsersSoapClient usersService = new UsersServiceReference.UsersSoapClient();
            VoiceServiceReference.VoiceSoapClient voiceService = new VoiceServiceReference.VoiceSoapClient();
            ContactsServiceReference.ContactsSoapClient contactsService = new ContactsServiceReference.ContactsSoapClient();
            ActionsServiceReference.ActionsSoapClient actionsService = new ActionsServiceReference.ActionsSoapClient();
            ScheduleServiceReference.ScheduleSoapClient scheduleService = new ScheduleServiceReference.ScheduleSoapClient();
        }
    }
}
