<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="gus.Modules.DNNContactFormModule.View" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnJsInclude FilePath="https://www.google.com/recaptcha/api.js" runat="server"/>

<dnn:DnnJsInclude FilePath="/DesktopModules/DNNContactFormModule/Scripts/civem-0.0.7.js" runat="server"/>

<div class="row">
        <div class="col-sm-9">
            
            <div class="form-group">
                <asp:Label id="lblName" AssociatedControlID="txtName" runat="server">Name</asp:Label>
                <asp:TextBox id="txtName" class="form-control" placeholder="Enter your name here..." title="Must enter your name" tabindex="1" runat="server"/>
            </div>
             
            <div class="form-group">
                <asp:Label AssociatedControlID="txtComment" runat="server">Comment</asp:Label>
                <asp:TextBox class="form-control" placeholder="Enter your enquiry here.." TextMode="MultiLine" cols="20" rows="6" id="txtComment" tabindex="2" name="txtComment" title="Must enter a message" runat="server"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <asp:Label AssociatedControlID="txtEmail" runat="server">Email</asp:Label>
                <asp:TextBox placeholder="Enter your email here.." class="form-control" id="txtEmail" name="Email" tabindex="3" TextMode="Email" title="Must enter your email address" runat="server"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <asp:Button id="btnSave" OnClick="btnSave_OnClick" class="btn btn-primary" TabIndex="5" Text="Submit" runat="server"/>
            </div>
            
            <div class="form-group">
              <asp:Panel id="PanelServerError" Visible="False" runat="server">
               <div class="alert alert-danger">
                <strong>Error!</strong> One or more fields are empty!
                </div>
            </asp:Panel>   
            </div>
             

            <div id="DivRecaptcha" class="g-recaptcha" runat="server"></div>
        </div>

        <div class="col-sm-3"></div>
</div>

