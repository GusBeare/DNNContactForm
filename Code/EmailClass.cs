
using DotNetNuke.Services.Mail;

namespace gus.Modules.DNNContactFormModule.Code
{
    public static class EmailClass
    {
      
        public static void SendDNNEmail(string EmailFrom, string EmailTo, string body, string subject)
        {
           
            // use the DNN API to send the email. This takes the configured host SMTP settings
            // if SMTP settings are not configured you will get an error
            Mail.SendEmail(EmailFrom,EmailTo, subject,body);

        }
        public static void SendExternalEmail(string EmailFrom, string EmailTo, string EmailBody)
        {

        }

    }
}