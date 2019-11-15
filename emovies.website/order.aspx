<%@ Page Title="order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="emovies.website.Order" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Order</h1>
    <div class="info info--order">
        <div class="form">
            <div class="form-row form-row--name form-row--upper">
                <ValidatedInput:Text ID="Name" LabelText="Name" runat="server" />
            </div>
            <div class="form-row form-row--email form-row--upper">
                <ValidatedInput:Text ID="Email" LabelText="Email" EnableClientScript="true" runat="server" />
            </div>
            <div class="form-row form-row--card-number form-row--upper">
                <ValidatedInput:Text ID="CardNumber" LabelText="Credit card number" EnableClientScript="true" runat="server" />
            </div>
            <div class="form-row form-row--lower">
                <asp:Label AssociatedControlID="CardType" CssClass="form-row__cell form-row__cell--label" runat="server">Credit card type</asp:Label>
                <asp:DropDownList ID="CardType" CssClass="form-row__card-type form-row__cell form-row__cell--input form-row__cell--select form-row__cell--white" runat="server">
                    <asp:ListItem>Mastercard</asp:ListItem>
                    <asp:ListItem>Visa</asp:ListItem>
                    <asp:ListItem>American Express</asp:ListItem>
                    <asp:ListItem>Discover</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-row form-row--lower">
                <asp:Label AssociatedControlID="futurePromotions" CssClass="form-row__cell form-row__cell--label form-row__cell--shifted" runat="server">Please email me<br>future promotions</asp:Label>
                <div class="form-row__cell form-row__cell--input form-row__cell--checkbox-container form-row__cell--white">
                    <asp:CheckBox ID="FuturePromotions" CssClass="form-row__checkbox" runat="server" Checked="False" />
                    <asp:Label ID="CheckImage" AssociatedControlID="FuturePromotions" CssClass="form-row__check-image" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="order order--submit-order">
        <asp:Button CssClass="order__button" Text="Submit order >>" type="submit" runat="server" />
    </div>
    <asp:ValidationSummary ID="OrderPageValidationSummary" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" HeaderText="Details Validation Issue" EnableClientScript="True" />
    <script type="text/javascript" src="Scripts/pageScripts/order.js"></script>
</asp:Content>
