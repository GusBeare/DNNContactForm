using System;
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
            var email = txtEmail.Text;
            var comments = txtComment.Text;

            var CallerIp = HttpContext.Current.Request.UserHostAddress;
            var CallerAgent = HttpContext.Current.Request.UserAgent;
            var CalledUrl = HttpContext.Current.Request.Url.OriginalString;


            // just make sure someone hasn't bypassed the in browser validation somehow
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(comments))
            {
                PanelServerError.Visible = true;
            }
            else
            {
                // Send the email
                EmailClass.SendDNNEmail("gus@carawaydesign.com", email, comments, "Email from web site Contact Form");

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