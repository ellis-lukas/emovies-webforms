﻿<%@ Page Title="order confirmation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="confirmation.aspx.cs" Inherits="emovies.website.Confirmation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Order confirmation</h1>
    <div class="info info--confirmation">
        <div class="form">
            <h2>Your details</h2>
            <div class="form-row form-row--upper">
                <div class="form-row__label-input-container">
                    <div class="form-row__cell form-row__cell--label">Name</div>
                    <asp:Label ID="Name" CssClass="form-row__cell form-row__cell--output" runat="server" />
                </div>
            </div>
            <div class="form-row form-row--upper">
                <div class="form-row__label-input-container">
                    <div class="form-row__cell form-row__cell--label">Email</div>
                    <asp:Label ID="Email" CssClass="form-row__cell form-row__cell--output" runat="server" />
                </div>
            </div>
            <div class="form-row form-row--upper">
                <div class="form-row__label-input-container">
                    <div class="form-row__cell form-row__cell--label">Credit card number</div>
                    <asp:Label ID="CardNumber" CssClass="form-row__cell form-row__cell--output" runat="server" />
                </div>
            </div>
            <div class="form-row form-row--lower">
                <div class="form-row__label-input-container">
                    <div class="form-row__cell form-row__cell--label">Credit card type</div>
                    <asp:Label ID="CardType" CssClass="form-row__cell form-row__cell--output" runat="server" />
                </div>
            </div>
            <div class="form-row form-row--lower">
                <div class="form-row__label-input-container">
                    <div class="form-row__cell form-row__cell--label form-row__cell--shifted">Please email me<br>future promotions</div>
                    <asp:Label ID="FuturePromotions" CssClass="form-row__cell form-row__cell--output" runat="server" />
                </div>
            </div>
        </div>
        <div class="summary">
            <h2>Your tickets</h2>
            <asp:Repeater ID="RepeaterConfirmation" runat="server">
                <ItemTemplate>
                    <div class="summary-row">
                        <div class="summary-row__cell summary-row__cell--movie"><%#Eval("MovieName")%></div>
                        <div class="summary-row__cell summary-row__cell--order"><%# Eval("Quantity") + " x " + Eval("Price", "{0:c}") %></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="total total--summary">
                <div class="total__cell total__cell--label total__cell--label-summary">Total</div>
                <asp:Label ID="TotalValue" CssClass="total__cell total__cell--value total__cell--value-summary" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="Scripts/pageScripts/confirmation.js"></script>
</asp:Content>
