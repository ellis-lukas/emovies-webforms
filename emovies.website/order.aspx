<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="emovies.website.Order" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Order</h1>
    <div class="info info--order">
        <div class="form">
            <div class="form-row form-row--upper">
                <label for="name" class="form-row__cell form-row__cell--label">Name</label>
                <input name="name" type="text" class="form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white">
            </div>
            <div class="form-row form-row--upper">
                <label for="email" class="form-row__cell form-row__cell--label">Email</label>
                <input name="email" type="text" class="form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white">
            </div>
            <div class="form-row form-row--upper">
                <label for="card-number" class="form-row__cell form-row__cell--label">Credit card number</label>
                <input name="card-number" type="text" class="form-row__cell form-row__cell--input form-row__cell--text form-row__cell--white">
            </div>
            <div class="form-row form-row--lower">
                <label for="card-type" class="form-row__cell form-row__cell--label">Credit card type</label>
                <select name="card-type" class="form-row__cell form-row__cell--input form-row__cell--select form-row__cell--white">
                    <option>A</option>
                </select>
            </div>
            <div class="form-row form-row--lower">
                <label for="future-promotions" class="form-row__cell form-row__cell--label form-row__cell--shifted">Please email me<br>
                    future promotions</label>
                <div class="form-row__cell form-row__cell--input form-row__cell--container form-row__cell--white">
                    <input type="checkbox" id="future-promotions" class="form-row__checkbox"><label class="form-row__checklabel" for="future-promotions"></label>
                </div>
            </div>
        </div>
    </div>
    <div class="order order--submit-order">
        <button class="order__button" type="button">Submit order >></button>
    </div>
</asp:Content>
