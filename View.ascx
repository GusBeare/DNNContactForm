<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="gus.Modules.DNNContactFormModule.View" %>


<div class="row">
        <div class="col-sm-9">
            
            <div class="form-group">
                <asp:Label id="lblName" AssociatedControlID="txtName" runat="server">Name</asp:Label>
                <asp:TextBox id="txtName" class="form-control" placeholder="Please enter your name..." tabindex="1" runat="server"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName"
                    runat="server"
                    ControlToValidate="txtName"
                    EnableClientScript="true"
                    SetFocusOnError="true"
                    Text="Name is required"
                    ClientIDMode="Static"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label AssociatedControlID="txtComment" runat="server">Comment</asp:Label>
                <asp:TextBox class="form-control" cols="30" rows="8" id="txtComment" tabindex="2" name="txtComment" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorComment"
                    runat="server"
                    ControlToValidate="txtComment"
                    EnableClientScript="true"
                    SetFocusOnError="true"
                    Text="Comment is required"
                    ClientIDMode="Static"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label AssociatedControlID="txtEmail" runat="server">Email</asp:Label>
                <asp:TextBox class="form-control" id="txtEmail" name="Email" tabindex="3" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    EnableClientScript="true"
                    SetFocusOnError="true"
                    Text="Valid Email Address is required"
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

