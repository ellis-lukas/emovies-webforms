<%@ Page Title="order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="emovies.website.Order" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Order</h1>
    <div class="info info--order">
        <div class="form">
            <%--<div class="form-row form-row--upper">
                <label for="Name" class="form-row__cell form-row__cell--label">Name</label>
                <asp:TextBox ID="Name" CssClass="form-row__name form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NamePresenceValidator" ControlToValidate="Name" runat="server" EnableClientScript="true" />
                <asp:RegularExpressionValidator ID="NameFormatValidator" ControlToValidate="Name" runat="server" EnableClientScript="true" />
            </div>--%>
            <div class="form-row form-row--upper">
                <label for="Name1" class="form-row__cell form-row__cell--label">Name</label>
                <UserControl:TextInput ID="Name1" CssClass="form-row__name form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white" runat="server" EnableClientScript="True";/>
            </div>
            <%--<div class="form-row form-row--upper">
                <label for="Email" class="form-row__cell form-row__cell--label">Email</label>
                <UserControl:TextInput CssClass="form-row__email form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white" runat="server" EnableClientScript="true" />
            </div>
            <div class="form-row form-row--upper">
                <label for="CardNumber" class="form-row__cell form-row__cell--label">Credit card number</label>
                <UserControl:TextInput ID="CardkkNumber" CssClass="form-row__card-number form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white" runat="server" EnableClientScript="true"/>
            </div>--%>
            <div class="form-row form-row--lower">
                <label for="CardType" class="form-row__cell form-row__cell--label">Credit card type</label>
                <asp:DropDownList ID="CardType" CssClass="form-row__card-type form-row__cell form-row__cell--input form-row__cell--select form-row__cell--white" runat="server">
                    <asp:ListItem>Mastercard</asp:ListItem>
                    <asp:ListItem>Visa</asp:ListItem>
                    <asp:ListItem>American Express</asp:ListItem>
                    <asp:ListItem>Discover</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-row form-row--lower">
                <asp:Label AssociatedControlID="futurePromotions" CssClass="form-row__cell form-row__cell--label form-row__cell--shifted" runat="server">Please email me<br>future promotions</asp:Label>
                <div class="form-row__cell form-row__cell--input form-row__cell--container form-row__cell--white">
                    <asp:CheckBox ID="FuturePromotions" CssClass="form-row__checkbox" runat="server" Checked="False" />
                    <asp:Label ID="CheckLabel" AssociatedControlID="FuturePromotions" CssClass="form-row__checklabel" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="order order--submit-order">
        <asp:Button CssClass="order__button" Text="Submit order >>" type="submit" OnClick="SubmitOrderClicked" runat="server" />
    </div>
    <asp:ValidationSummary ID="OrderPageValidationSummary" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" HeaderText="Details Validation Issue" EnableClientScript="True" />
    <script type="text/javascript" src="Scripts/pageScripts/order.js"></script>
</asp:Content>
