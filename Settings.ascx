<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="gus.Modules.DNNContactFormModule.Settings" %>

  
<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

	<h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead"><a href="#" class="dnnSectionExpanded">
	    <%=LocalizeString("BasicSettings")%>
	</a></h2>
	<fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="lblGoogleRecaptchaCode" runat="server" /> 
            <asp:TextBox ID="txtGoogleRecaptchaCode" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblTargetEmailAddress" runat="server" />
            <asp:TextBox ID="txtTargetEmailAddress" runat="server" />
        </div>
          <div class="dnnFormItem">
            <dnn:label ID="lblSuccessPageUrl" runat="server" />
            <asp:TextBox ID="txtSuccessPageUrl" runat="server" />
        </div>
    </fieldset>


