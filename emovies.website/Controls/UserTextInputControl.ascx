<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserTextInputControl.ascx.cs" Inherits="emovies.website.Controls.UserTextInputControl" %>
<asp:Label ID=InputLabel AssociatedControlID="TextInput" CssClass="form-row__cell form-row__cell--label" runat="server"></asp:Label>
<asp:TextBox CssClass="form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white" ID="TextInput" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator" ControlToValidate="TextInput" runat="server"/>
<asp:RegularExpressionValidator ID="RegularExpressionValidator" ControlToValidate="TextInput" runat="server" />