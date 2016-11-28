

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

namespace gus.Modules.DNNContactFormModule
{
    public partial class Settings : DNNContactFormModuleModuleSettingsBase
    {
        #region Base Method Implementations

        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack) return;
               
                //Check for existing settings and use those on this page    
                if(Settings.Contains("GoogleRecaptchaCode"))
                    txtGoogleRecaptchaCode.Text = Settings["GoogleRecaptchaCode"].ToString();
			
                if (Settings.Contains("ContactUsTargetEmailAddress"))
                    txtTargetEmailAddress.Text = Settings["ContactUsTargetEmailAddress"].ToString();

                if (Settings.Contains("ContactUsSuccessPageUrl"))
                    txtSuccessPageUrl.Text = Settings["ContactUsSuccessPageUrl"].ToString();

             
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

       
        public override void UpdateSettings()
        {
            try
            {
                var modules = new ModuleController();
                
                // module settings are used so that these settings are the same for all instances of the module
                modules.UpdateModuleSetting(ModuleId, "GoogleRecaptchaCode", txtGoogleRecaptchaCode.Text);
                modules.UpdateModuleSetting(ModuleId, "ContactUsTargetEmailAddress", txtTargetEmailAddress.Text);
                modules.UpdateModuleSetting(ModuleId, "ContactUsSuccessPageUrl", txtSuccessPageUrl.Text);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    }
}