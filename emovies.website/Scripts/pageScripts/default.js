const updateButton = document.querySelector(".update__button");
const orderButton = document.querySelector(".order__button");
const totalValueCell = document.querySelector(".total__cell--value");
const movieList = document.querySelectorAll(".table-row");

var quantityArrayOnSubmission = [];
var quantityArrayOnUpdate = [];

function prepareMovieTable() {
    updateTotal();
}

function update() {
    updateTotal();
    captureQuantitiesOnUpdate();
}

function updateTotal() {
    totalValueCell.innerHTML = "£" + calculateTotal().toFixed(2);
}

function calculateTotal() {
    var total = 0.0;
    movieList.forEach
    ((movie) =>  {total += individualMovieTotal(movie); });
    return total;
}

function individualMovieTotal(movie) {
    var numberOfTicketsOrdered = quantityCellValue(movie);
    var moviePrice = priceCellValue(movie);
    var movieTotal = numberOfTicketsOrdered * moviePrice;
    return movieTotal;
}

function priceCellValue(movie) {
    var priceCell = movie.querySelector(".table-row__price-bucket");
    var priceCellValue = parseFloat(priceCell.value);
    return priceCellValue;
}

function quantityCellValue(movie) {
    var quantityCell = movie.querySelector(".table-row__cell--quantity");
    if (quantityCell.value == "") {
        return 0;
    }
    return parseInt(quantityCell.value);
}

function QuantityInputs() {
    this.quantityCells = document.querySelectorAll(".table-row__cell--quantity");
    this.areZero = function () { return arrayAllZeros(this.extractArray()); }
    this.extractArray = function () { return extractQuantityArray(this.quantityCells); }
}

function arrayAllZeros(array) {
    for (var i = 0; i < array.length; i++) {
        if (array[i] != 0) {
            return false;
        }
    }
    return true;
}

function extractQuantityArray(quantityCells) {
    return Array.from(quantityCells).map(DOMObjectValue);
}

function DOMObjectValue(DOMObject) {
    return DOMObject.value;
}

function ValidateQuantityInputsNonZero(sender, args) {
    var quantityInputs = new QuantityInputs();
    args.IsValid = !(quantityInputs.areZero());
}

function captureQuantitiesOnUpdate() {
    quantityArrayOnUpdate = new QuantityInputs().extractArray();
}

function captureQuantitiesOnSubmission() {
    quantityArrayOnSubmission = new QuantityInputs().extractArray();
}

function ValidateSelectionUpdated(sender, args) {
    captureQuantitiesOnSubmission();
    if (arraysAreEqual(quantityArrayOnSubmission, quantityArrayOnUpdate)) {
        args.IsValid = true;
    }
    else if (arrayAllZeros(quantityArrayOnSubmission)) {
        args.IsValid = true;
    }
    else {
        args.IsValid = false;
    }
}

function arraysAreEqual(arrayA, arrayB) {
    return (JSON.stringify(arrayA) === JSON.stringify(arrayB));
}

prepareMovieTable();
updateButton.addEventListener("click", update);








