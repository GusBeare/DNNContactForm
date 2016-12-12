using System;
using System.Dynamic;
using Simple.Data;
using DotNetNuke.Data;

namespace gus.Modules.DNNContactFormModule.Code
{
    public static class DatabaseClass
    {
        public static void InsertContactDetails(string name, string email, string phone, string comment, string IP, string agent)
        {
            // use Simple.Data to open the DNN database
            var db = Database.OpenNamedConnection("SiteSQLServer");
            dynamic model = new ExpandoObject();
            model.Name = name;
            model.Email = email;
            model.Phone = phone;
            model.IpAddress = IP;
            model.UserAgent = agent;
            model.Comment = comment;
            model.CreatedDate = DateTime.Today;

            db.ContactUsFormLog.Insert(model);
        }

    }
}