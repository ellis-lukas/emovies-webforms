<%@ Page Title="order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="emovies.website.Order" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Order</h1>
    <div class="info info--order">
        <div class="form">
            <div class="form-row form-row--upper">
                <label for="name" class="form-row__cell form-row__cell--label">Name</label>
                <asp:TextBox ID="name" CssClass="form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white" runat="server"></asp:TextBox>
            </div>
            <div class="form-row form-row--upper">
                <label for="email" class="form-row__cell form-row__cell--label">Email</label>
                <asp:TextBox ID="email" CssClass="form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white" runat="server"></asp:TextBox>
            </div>
            <div class="form-row form-row--upper">
                <label for="cardNumber" class="form-row__cell form-row__cell--label">Credit card number</label>
                <asp:TextBox ID="cardNumber" CssClass="form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white" runat="server"></asp:TextBox>
            </div>
            <div class="form-row form-row--lower">
                <label for="cardType" class="form-row__cell form-row__cell--label">Credit card type</label>
                <asp:DropDownList ID="cardType" CssClass="form-row__cell form-row__cell--input form-row__cell--select form-row__cell--white" runat="server">
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-row form-row--lower">
                <asp:Label AssociatedControlID="futurePromotions" CssClass="form-row__cell form-row__cell--label form-row__cell--shifted" runat="server">Please email me<br>future promotions</asp:Label>
                <div class="form-row__cell form-row__cell--input form-row__cell--container form-row__cell--white">
                    <asp:CheckBox ID="futurePromotions" CssClass="form-row__checkbox" runat="server" Checked="False" />
                    <asp:Label ID="checkLabel" AssociatedControlID="futurePromotions" CssClass="form-row__checklabel" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="order order--submit-order">
        <asp:Button CssClass="order__button" Text="Submit order >>" type="submit" runat="server" OnClick="SubmitOrderClicked" />
    </div>
    <script type="text/javascript" src="Scripts/pageScripts/order.js"></script>
</asp:Content>
