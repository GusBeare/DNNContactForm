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
              
                // collect the data from the form and validate
                var name = txtName.Text;
                var email = txtEmail.Text;
                var comments = txtComment;



            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
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

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }
    }
}