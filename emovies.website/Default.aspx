﻿<%@ Page Title="browse movie tickets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="emovies.website.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Browse movie tickets</h1>
    <div class="info info--movie">
        <div class="table">
            <asp:Repeater ID="BrowsePageRepeater" runat="server">
                <HeaderTemplate>
                    <div class="table-heading">
                        <div class="table-heading__cell table-heading__cell--movie">Movie</div>
                        <div class="table-heading__cell table-heading__cell--quantity">Quantity</div>
                        <div class="table-heading__cell table-heading__cell--price">Price</div>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="table-row">
                        <div class="table-row__cell table-row__cell--movie table-row__cell--blue"><%# Eval("Name") %></div>
                        <asp:TextBox ID="quantityCell" CssClass="table-row__cell table-row__cell--quantity table-row__cell--white" type="number" value="0" runat="server"></asp:TextBox>
                        <div class="table-row__cell table-row__cell--price table-row__cell--blue"><%# Eval("Price", "{0:c}") %></div>
                        <input type="hidden" class="table-row__price-currencyless" value="<%# Eval("Price") %>" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:CustomValidator ID="NotZerosValidator" ClientValidationFunction="ClientValidateNotZeros" OnServerValidate="ServerValidateNotZeros" runat="server"/>
            <asp:CustomValidator ID="NoNegativesValidator" ClientValidationFunction="ClientValidateNoNegatives" OnServerValidate="ServerValidateNoNegatives" runat="server"/>
            <asp:CustomValidator ID="RangeValidator" ClientValidationFunction="ClientValidateInRange" OnServerValidate="ServerValidateInRange" runat="server" />
            <asp:CustomValidator ID="FormatValidator" OnServerValidate="ServerValidateFormat" runat="server" />
            <div class="total total--table">
                <div class="total__cell total__cell--label total__cell--label-table">Total</div>
                <div class="total__cell total__cell--value total__cell--value-table"></div>
            </div>
        </div>
        <div class="update">
            <asp:Button CausesValidation="false" Text="Update" OnClientClick="return false;" CssClass="update__button" runat="server"/>
        </div>
    </div>
    <div class="notice">Tickets are only valid for use on the day of purchase</div>
    <div class="order order--order-now">
        <asp:Button ID="OrderNowButton" CssClass="order__button" Text="Order now >>" OnClick="OrderNowClicked" runat="server" />
    </div>
    <asp:ValidationSummary EnableClientScript="true" ID="BrowsePageValidationSummary" runat="server" />
    <script type="text/javascript" src="Scripts/pageScripts/default.js"></script>
</asp:Content>
