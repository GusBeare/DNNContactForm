using System;
using System.Text;
using System.Web;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using gus.Modules.DNNContactFormModule.Code;

namespace gus.Modules.DNNContactFormModule
{
    public partial class View : DNNContactFormModuleModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack){return;}

            try
            {
                // add the recaptcha key from module settings
                if (Settings.Contains("GoogleRecaptchaCode"))
                {
                    var key = Settings["GoogleRecaptchaCode"].ToString(); 
                    DivRecaptcha.Attributes.Add("data-sitekey", key);

                }

                // add attributes for HTML5 required fields
                txtName.Attributes.Add("required data-errormessage-value-missing", "Must enter your name!");
                txtEmail.Attributes.Add("required data-errormessage-value-missing","Must enter your email address!");
                txtComment.Attributes.Add("required data-errormessage-value-missing","Must enter a message!");

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
           
            var name = txtName.Text;
            var EnquirerEmail = txtEmail.Text;
            var comments = txtComment.Text;

            var CallerIp = HttpContext.Current.Request.UserHostAddress;
            var CallerAgent = HttpContext.Current.Request.UserAgent;
            var CalledUrl = HttpContext.Current.Request.Url.OriginalString;


            // just make sure someone hasn't bypassed the in browser validation somehow
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(EnquirerEmail) || string.IsNullOrEmpty(comments))
            {
                PanelServerError.Visible = true;
            }
            else
            {

                // get the recipient email in settings (site admin)
                var AdminEmail = Settings.Contains("ContactUsTargetEmailAddress") ? Settings["ContactUsTargetEmailAddress"].ToString() : "mybackupEmail.com";

                // get the localised email subject
                var alias = PortalAlias.HTTPAlias;
                var sub = Localization.GetString("EmailSubject.Text", LocalResourceFile) + " " + alias;

                // build the email body
                var body = new StringBuilder();
                body.AppendLine("<p><strong>Name: </strong>" + name + "</p>");
                body.AppendLine("<p><strong>Email: </strong>" + EnquirerEmail + "</p>");
                body.AppendLine("<hr>");
                body.AppendLine("<p>" + comments + "</p>");

                // in this instance the to and from email addresses are the same 
                // since this is from the web site admin to the web site admin
                EmailClass.SendDNNEmail(AdminEmail, AdminEmail, body.ToString(), sub);

                // redirect if the setting is there
                if (Settings.Contains("ContactUsSuccessPageUrl"))
                {
                    var SuccessPage = Settings["ContactUsSuccessPageUrl"].ToString();
                    Response.Redirect(SuccessPage);
                }
                else
                {
                    // otherwise, hide the form and show a success message
                    PanelContactUsForm.Visible = false;
                    PanelContactUsFormSubmitted.Visible = true;
                }
                
                
            }

        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

    }
}