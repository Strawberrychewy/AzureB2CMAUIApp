# AzureB2CMAUIApp

A couple of things to note before you start looking at this.
1. This is only the app code. You would need to set up the Azure Cloud Services in order to use the application.
This project will include a basic WebAPI, so you would need to deploy it using the appropriate IDs' and URIs' mentioned throughout the following videos below.
You only need to test the redirection from logging in, so need to test any endpoints after login.

Please follow these links in order to get this to work:
Microsoft Login
https://www.youtube.com/watch?v=erP42WqOi0Q&t=669s

Social Login using Azure B2C (uses Twitter but the following link replaces twitter for generic term "Social")
https://www.youtube.com/watch?v=AIO2qOKC7Vc

Social Login using additional Login Flows (Google)
https://www.youtube.com/watch?v=PpJ8YqzoWds

The files you would need to edit within the project to align with the Azure cloud is as follows (Will be tagged with Curly Braces "{}" ):
MAUI App:
appsettings.json
MsalActivity.cs
MainActivity.cs
AndroidManifest.xml

Web API:
appsettings.json

2. Once everything is set up on the cloud and all the keys and ids match in your project, App.Xaml.cs in the MAUI app will use an injected LoginPage. Both Microsoft and Social Logins should work if this is used. However, if you use the injected AppShell instead, it will only work for Microsoft login. Social Login will not redirect back into the app.

3. If you cancel the login flow - it will crash on UserCancelledException. I haven't dealt with it in my main app yet, but will once I get back into developing. Just restart the app if this is the case.
