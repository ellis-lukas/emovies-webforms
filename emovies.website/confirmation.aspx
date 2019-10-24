<%@ Page Title="order confirmation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="confirmation.aspx.cs" Inherits="emovies.website.Confirmation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Order confirmation</h1>
    <div class="info info--confirmation">
        <div class="form">
            <h2>Your details</h2>
            <div class="form-row form-row--upper">
                <div class="form-row__cell form-row__cell--label">Name</div>
                <div class="form-row__cell form-row__cell--output"><%=VisitorInfo.Name%></div>
            </div>
            <div class="form-row form-row--upper">
                <div class="form-row__cell form-row__cell--label">Email</div>
                <div class="form-row__cell form-row__cell--output"><%=VisitorInfo.Email%></div>
            </div>
            <div class="form-row form-row--upper">
                <div class="form-row__cell form-row__cell--label">Credit card number</div>
                <div class="form-row__cell form-row__cell--output"><%=VisitorInfo.CardNumber%></div>
            </div>
            <div class="form-row form-row--lower">
                <div class="form-row__cell form-row__cell--label">Credit card type</div>
                <div class="form-row__cell form-row__cell--output"><%=VisitorInfo.CardType%></div>
            </div>
            <div class="form-row form-row--lower">
                <div class="form-row__cell form-row__cell--label form-row__cell--shifted">Please email me<br>
                    future promotions</div>
                <div class="form-row__cell form-row__cell--output"><%=VisitorInfo.FuturePromotions%></div>
            </div>
        </div>
        <div class="summary">
            <h2>Your tickets</h2>
            <div class="summary-row">
                <div class="summary-row__cell summary-row__cell--movie">Movie 1</div>
                <div class="summary-row__cell summary-row__cell--order">1 x £4.99</div>
            </div>
            <div class="summary-row">
                <div class="summary-row__cell summary-row__cell--movie">Movie 2</div>
                <div class="summary-row__cell summary-row__cell--order">2 x £4.99</div>
            </div>
            <div class="total total--summary">
                <div class="total__cell total__cell--label total__cell--label-summary">Total</div>
                <div class="total__cell total__cell--value total__cell--value-summary">£11.98</div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="Scripts/pageScripts/confirmation.js"></script>
</asp:Content>