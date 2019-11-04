<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserTextInputControl.ascx.cs" Inherits="emovies.website.Controls.UserTextInputControl" %>

<asp:TextBox ID="TextInput" CssClass="form-row__name form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator" ControlToValidate="TextInput" runat="server" EnableClientScript="true" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator" ControlToValidate="TextInput" runat="server" EnableClientScript="true" />