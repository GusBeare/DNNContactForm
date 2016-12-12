using System;
using System.Dynamic;
using Simple.Data;
using DotNetNuke.Data;
using DotNetNuke.Services.Exceptions;

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
                model.CreatedDate = DateTime.Now;

                // use string indexers with Simple.Data to supply the object qualifier and table name
                // see: http://stackoverflow.com/questions/10961471/retrive-data-with-simple-data-from-a-table-with-its-name-passed-in-as-a-variable

                const string tableName = "ContactUsFormLog";
                var sdP = new SqlDataProvider();
                var objectQualifier = sdP.ObjectQualifier;
              
                var newRow = db[objectQualifier][tableName].Insert(model);
           
         
        }

    }
}