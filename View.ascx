<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="gus.Modules.DNNContactFormModule.View" %>



<div class="row">
        <div class="col-sm-12">
         <div id="ValidationSummarySection">
                <asp:ValidationSummary
                    runat="server"
	                resourcekey="ValidationSummaryContactForm" 
                    ShowMessageBox="false" 
                    DisplayMode="BulletList" 
                    ShowSummary="true" 
                    ValidationGroup="ValSummary"
	                CssClass="dnnFormMessage dnnFormValidationSummary"/>
            </div>
        </div>
</div>

<div class="row">
        <div class="col-sm-9">
            
            <div class="form-group">
                <asp:Label id="lblName" AssociatedControlID="txtName" runat="server">Name</asp:Label>
                <asp:TextBox id="txtName" class="form-control" placeholder="Please enter your name..." tabindex="1" runat="server"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName"
                    runat="server"
                    ControlToValidate="txtName"
                    EnableClientScript="true"
                    ValidationGroup="ValSummary"
                    SetFocusOnError="true"
                    Text="*"
                    Display="None"
                    ClientIDMode="Static"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="Comment">Comment</label>
                <textarea class="form-control" cols="30" rows="8" id="Comment" form="ContactForm" tabindex="2" name="Comment"></textarea>
            </div>

            <div class="form-group">
                <asp:Label AssociatedControlID="txtEmail" runat="server">Email</asp:Label>
                <asp:TextBox class="form-control" id="txtEmail" name="Email" tabindex="3" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    EnableClientScript="true"
                    ValidationGroup="ValSummary"
                    SetFocusOnError="true"
                    Text="*"
                    Display="None"
                    ClientIDMode="Static"></asp:RequiredFieldValidator>
              
            </div>

            <div class="form-group">
                <asp:Button id="btnSave" OnClick="btnSave_OnClick" class="btn btn-primary" TabIndex="5" Text="Submit" runat="server"/>
            </div>
            <div class="g-recaptcha" data-sitekey="6Lfe_CATAAAAAFmKjVjdr5BwYsVXHu7hxQgRH0Bz"></div>
        </div>

        <div class="col-sm-3"></div>
</div>

