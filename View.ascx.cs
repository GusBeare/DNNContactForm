using System;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;

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

            // just make sure someone hasn't bypassed the in browser validation somehow
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(comments))
            {
                PanelServerError.Visible = true;
            }
            else
            {
                if (!Settings.Contains("ContactUsSuccessPageUrl")) return;
                var SuccessPage = Settings["ContactUsSuccessPageUrl"].ToString();
                Response.Redirect(SuccessPage);
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