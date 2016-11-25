﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="gus.Modules.DNNContactFormModule.View" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnJsInclude FilePath="https://www.google.com/recaptcha/api.js" runat="server"/>


<div class="row">
        <div class="col-sm-9">
            
            <div class="form-group">
                <asp:Label id="lblName" AssociatedControlID="txtName" runat="server">Name</asp:Label>
                <asp:TextBox id="txtName" class="form-control" placeholder="Enter your name here..." tabindex="1" runat="server"/>
            </div>
              <div><asp:RequiredFieldValidator ID="RequiredFieldValidatorName"
                    runat="server"
                    ControlToValidate="txtName"
                    EnableClientScript="true"
                    SetFocusOnError="true"
                    Text="Name is required"
                    ClientIDMode="Static" CssClass=""></asp:RequiredFieldValidator>
                </div>

            <div class="form-group">
                <asp:Label AssociatedControlID="txtComment" runat="server">Comment</asp:Label>
                <asp:TextBox class="form-control" placeholder="Enter your enquiry here.." TextMode="MultiLine" cols="20" rows="6" id="txtComment" tabindex="2" name="txtComment" runat="server"></asp:TextBox>
            </div>
              <div>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidatorComment"
                    runat="server"
                    ControlToValidate="txtComment"
                    EnableClientScript="true"
                    SetFocusOnError="true"
                    Text="Comment is required"
                    ClientIDMode="Static" CssClass=""></asp:RequiredFieldValidator>
               </div> 

            <div class="form-group">
                <asp:Label AssociatedControlID="txtEmail" runat="server">Email</asp:Label>
                <asp:TextBox placeholder="Enter your enquiry here.." class="form-control" id="txtEmail" name="Email" tabindex="3" runat="server"></asp:TextBox>
            </div>
            <div>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    EnableClientScript="true"
                    SetFocusOnError="true"
                    Text="Valid Email Address is required" CssClass="dnnFormMessage_dnnFormError"
                    ClientIDMode="Static"></asp:RequiredFieldValidator>    
                </div>

            <div class="form-group">
                <asp:Button id="btnSave" OnClick="btnSave_OnClick" class="btn btn-primary" TabIndex="5" Text="Submit" runat="server"/>
            </div>
            <div id="DivRecaptcha" class="g-recaptcha" runat="server"></div>
        </div>

        <div class="col-sm-3"></div>
</div>

