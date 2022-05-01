# Farapayamak CSharp

## Introduction
Here we've provided a complete 3rd-party library (SDK) for C# developers that covers both **SOAP** and **REST** webservices. Before using, make sure you have provided a [valid account in Farapayamak corporation](https://farapayamak.ir/start/).

### معرفی
فراپیامک مجموعۀ کامل از متدهای اتصال به وب سرویس **REST** و **SOAP** این شرکت را برای توسعه دهندگان C# فراهم نموده. قبل از استفاده از این کتابخانه، نیاز به [خرید پنل فراپیامک](https://farapayamak.ir/start/) دارید

## Instructions
### REST
For consuming the REST web service, You can use our provided (https://www.nuget.org/packages/Farapayamak.RestClient)[nuget package] or manually add the _RestClient_ file from the _lib_ folder into your project.

```
Install-Package Farapayamak.RestClient -Version 1.1.0
```
### SOAP
For consuming the SOAP web service, you can add our (http://api.payamak-panel.com)[endpoints] (listed below) as _service reference_ to your project or take a look at the provided _QuickStart_ project to make the life easier.

- http://api.payamak-panel.com/post/send.asmx
- http://api.payamak-panel.com/post/contacts.asmx
- http://api.payamak-panel.com/post/receive.asmx
- http://api.payamak-panel.com/post/actions.asmx
- http://api.payamak-panel.com/post/Users.asmx
- http://api.payamak-panel.com/post/Schedule.asmx
- http://api.payamak-panel.com/post/Voice.asmx

## Usage
This is a simple usage for both REST and SOAP APIs:
```c#
// REST
RestClient restClient = new RestClient("username", "password");
Console.Write(restClient.SendSMS("09123456789", "5000xxx", "test sms"));
// SOAP
SendSoapClient sendService = new SendSoapClient();
Console.Write(sendService.SendSimpleSMS2("username", "password", "09123456789", "5000xxx", "test sms by soap", false));
```


## REST or SOAP?
We support a small number of methods in REST against the SOAP web service that supports the entire ones.

## REST Methods
We're currently supporting the following methods in REST web service:

```c#
restClient.SendSMS(to, from, text, isFlash);
restClient.GetDeliveries2(recId);
restClient.GetMessages(location, from, index, count);
restClient.GetCredit();
restClient.GetBasePrice();
restClient.GetUserNumbers();
restClient.BaseServiceNumber(text, to, bodyId);
```

## SOAP Methods
We support a wide range of methods in SOAP web service. They're scope separated. Let's review all the SOAP web service methods.

### Send Web Service

```c#
soapClient.GetCredit();
soapClient.GetDeliveries(recIds);
soapClient.GetDeliveries3(recId);
soapClient.GetSmsPrice(irancellCount, mtnCount, from, text);
soapClient.SendByBaseNumber(text, to, bodyId);
soapClient.SendByBaseNumber2(text, to, bodyId);
soapClient.SendByBaseNumber3(text, to);
soapClient.SendSimpleSMS(to, from, text, isflash);
soapClient.SendSimpleSMS2(to, from, text, isflash);
soapClient.SendSms(to, from, text, isflash, udh, recId);
soapClient.SendSms2(to, from, text, isflash, udh, recId, status, filterId);
soapClient.SendMultipleSMS(to, from, text, isflash, udh, recId);
soapClient.SendMultipleSMS2(to, from, text, isflash, udh, recId);
```

### Receive Web Service

```c#
soapClient.ChangeMessageIsRead(msgIds);
soapClient.GetInboxCount();
soapClient.GetLatestReceiveMsg(sender, receiver);
soapClient.GetMessages(location, from, index, count);
soapClient.GetMessagesAfterID(location, from, count, msgId);
soapClient.GetMessagesFilterByDate(location, from, index, count, dateFrom, dateTo, isRead);
soapClient.GetMessagesReceptions(msgId, fromRows);
soapClient.GetMessagesWithChangeIsRead(location, from, index, count, isRead, changeIsRead);
soapClient.GetOutBoxCount();
soapClient.RemoveMessages(location, msgIds);
```

### User Web Service

```c#
soapClient.AddUser(productId, descriptions, mobileNumber, emailAddress, nationalCode, 
        name, family, corporation, phone, fax, address, postalCode, certificateNumber);
soapClient.AddUserWithLocation(productId, descriptions, mobileNumber, emailAddress, nationalCode, 
    name, family, corporation, phone, fax, address, postalCode, certificateNumber, country, province, city);
soapClient.AddUserWithMobileNumber(productId, mobileNumber, firstName, lastName, email);
soapClient.AddUserWithMobileNumber2(productId, mobileNumber, firstName, lastName, userName, email);
soapClient.AddUserWithUserNameAndPass(productId, descriptions, mobileNumber, emailAddress, nationalCode, 
    name, family, corporation, phone, fax, address, postalCode, certificateNumber, targetUserName, targetUserPassword);
soapClient.AuthenticateUser();
soapClient.ChangeUserCredit(amount, description, targetUsername, GetTax);
soapClient.DeductUserCredit(amount, description);
soapClient.ForgotPassword(mobileNumber, emailAddress, targetUsername);
soapClient.GetCities(provinceId);
soapClient.GetEnExpireDate();
soapClient.GetExpireDate();
soapClient.GetProvinces();
soapClient.GetUserBasePrice(targetUsername);
soapClient.GetUserCredit(targetUsername);
soapClient.GetUserCredit2();
soapClient.GetUserDetails(targetUsername);
soapClient.GetUserIsExist(targetUsername);
soapClient.GetUserNumbers();
soapClient.GetUserTransactions(targetUsername, creditType, dateFrom, dateTo, keyword);
soapClient.GetUserWallet();
soapClient.GetUserWalletTransaction(dateFrom, dateTo, count, startIndex, payType, payLoc);
soapClient.GetUsers();
soapClient.RemoveUser(targetUsername);
```

### Voice Web Service

```c#
soapClient.SendBulkSpeechText(title, body, receivers, DateToSend, repeatCount);
soapClient.SendBulkVoiceSMS(title, voiceFileId, receivers, DateToSend, repeatCount);
soapClient.UploadVoiceFile(title, base64StringFile);
```

### Contacts Web Service

```c#
soapClient.AddContact(groupIds, firstname, lastname, nickname, corporation, mobilenumber,
        phone, fax, birthdate, email, gender, province, city, address, postalCode, additionaldate,
        additionaltext, descriptions);
soapClient.AddContactEvents(contactId, eventName, eventType, eventDate);
soapClient.AddGroup(groupName, Descriptions, showToChilds);
soapClient.ChangeContact(contactId, firstname, lastname, nickname, corporation, mobilenumber,
        phone, fax, email, gender, province, city, address, postalCode, contactStatus,
        additionaltext, descriptions);
soapClient.ChangeGroup(groupId, groupName, Descriptions, showToChilds, groupStatus);
soapClient.CheckMobileExistInContact(mobileNumber);
soapClient.GetContactEvents(contactId);
soapClient.GetContacts(groupId, keyword, from, count);
soapClient.GetContactsByID(contactId, status);
soapClient.GetGroups();
soapClient.MergeGroups(originGroupId, destinationGroupId, deleteOriginGroup);
soapClient.RemoveContact(mobilenumber);
soapClient.RemoveContactByContactID(contactId);
soapClient.RemoveGroup(groupId);
```

### Schedule Web Service

```c#
soapClient.AddNewMultipleSchedule(to, from, text, isflash, scheduleDateTime, period);
soapClient.AddNewUsance(to, from, text, isflash, scheduleStartDateTime, countrepeat,
        scheduleEndDateTime, periodType);
soapClient.AddSchedule(to, from, text, isflash, scheduleDateTime, period);
soapClient.GetScheduleDetails(scheduleId);
soapClient.GetScheduleStatus(scheduleId);
soapClient.RemoveSchedule(scheduleId);
```

### Bulk Web Service

```c#
soapClient.AddNumberBulk(from, title, messages, receivers, DateToSend);
soapClient.BulkReception(bulkId, maximumRows, startRowIndex);
soapClient.BulkReceptionCount(bulkId);
soapClient.GetBulkDeliveries(recIds);
soapClient.GetBulkDeliveries2(recId);
soapClient.GetBulkDetails(bulkdId);
```
