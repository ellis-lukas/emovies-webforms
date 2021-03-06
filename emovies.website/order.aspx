﻿<%@ Page Title="order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="emovies.website.Order" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Order</h1>
    <div class="info info--order">
        <div class="form">
            <div class="form-row form-row--upper">
                <ValidatedInput:Text ID="Name" LabelText="Name" runat="server" />
            </div>
            <div class="form-row form-row--upper">
                <ValidatedInput:Text ID="Email" LabelText="Email" runat="server" />
            </div>
            <div class="form-row form-row--upper">
                <ValidatedInput:Text ID="CardNumber" LabelText="Credit card number" runat="server" />
            </div>
            <div class="form-row form-row--lower">
                <div class="form-row__label-input-container">
                    <asp:Label AssociatedControlID="CardType" CssClass="form-row__cell form-row__cell--label" Text="Credit card type" runat="server"/>
                    <asp:DropDownList ID="CardType" CssClass="form-row__card-type form-row__cell form-row__cell--input form-row__cell--select form-row__cell--white" runat="server">
                        <asp:ListItem>Mastercard</asp:ListItem>
                        <asp:ListItem>Visa</asp:ListItem>
                        <asp:ListItem>American Express</asp:ListItem>
                        <asp:ListItem>Discover</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-row form-row--lower">
                <div class="form-row__label-input-container">
                    <asp:Label AssociatedControlID="futurePromotions" CssClass="form-row__cell form-row__cell--label form-row__cell--shifted" Text="Please email me<br>future promotions" runat="server"/>
                    <div class="form-row__cell form-row__cell--input form-row__cell--checkbox-container form-row__cell--white">
                        <asp:CheckBox ID="FuturePromotions" CssClass="form-row__checkbox" runat="server" Checked="False" />
                        <asp:Label ID="CheckImage" AssociatedControlID="FuturePromotions" CssClass="form-row__check-image" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="order order--submit-order">
        <asp:Button CssClass="order__button" Text="Submit order >>" type="submit" runat="server" OnClick="SubmitOrderClicked" />
    </div>
    <script type="text/javascript" src="Scripts/pageScripts/order.js"></script>
</asp:Content>
