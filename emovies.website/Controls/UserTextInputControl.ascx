<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserTextInputControl.ascx.cs" Inherits="emovies.website.Controls.UserTextInputControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div class="form-row__label-input-container">
    <asp:Label ID="InputLabel" AssociatedControlID="TextInput" CssClass="form-row__cell form-row__cell--label" runat="server"></asp:Label>
    <asp:TextBox CssClass="form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white" ID="TextInput" runat="server" />
</div>

<div class="form-row__validators-container">
    <asp:RequiredFieldValidator CssClass="form-row__validator form-row__required-field-validator" ID="RequiredFieldValidator" ControlToValidate="TextInput" runat="server" />
    <asp:RegularExpressionValidator CssClass="form-row__validator form-row__regular-expression-validator" ID="RegularExpressionValidator" ControlToValidate="TextInput" runat="server" />
    <ajaxToolkit:ValidatorCalloutExtender HighlightCssClass="form-row__cell--invalid-required" ID="RVExtender" runat="server" TargetControlID="RequiredFieldValidator" CssClass="required-extender" EnableViewState="true" />
    <ajaxToolkit:ValidatorCalloutExtender HighlightCssClass="form-row__cell--invalid-regular-expression" ID="REExtender" runat="server" TargetControlID="RegularExpressionValidator" CssClass="regular-expression-extender" />
</div>

