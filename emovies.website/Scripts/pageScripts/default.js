const updateButton = document.querySelector(".update__button");
const orderButton = document.querySelector(".order__button");
const totalValueCell = document.querySelector(".total__cell--value");
const movieList = document.querySelectorAll(".table-row");

function updateClicked()
{
    if (Page_ClientValidate()) {
        updateTotal();
    }
    else {
        totalValueCell.innerHTML = "£" + 0.00.toFixed(2);
    }
}

function updateTotal()
{
    totalValueCell.innerHTML = "£" + calculateTotal().toFixed(2);
}

function calculateTotal()
{
    var total = 0.0;
    movieList.forEach
    ((movie) =>  {total += individualMovieTotal(movie); });
    return total;
}

function individualMovieTotal(movie)
{
    var numberOfTicketsOrdered = quantityCellValue(movie);
    var moviePrice = priceCellValue(movie);
    var movieTotal = numberOfTicketsOrdered * moviePrice;
    return movieTotal;
}

function priceCellValue(movie)
{
    var priceCell = movie.querySelector(".table-row__price-currencyless");
    var priceCellValue = parseFloat(priceCell.value);
    return priceCellValue;
}

function quantityCellValue(movie)
{
    var quantityCell = movie.querySelector(".table-row__cell--quantity");
    if (quantityCell.value == "") {
        return 0;
    }
    return parseInt(quantityCell.value);
}

function QuantityArrayMapper()
{
    this.quantityCells = document.querySelectorAll(".table-row__cell--quantity");
    this.mapFromRepeater = function () { 
        var arrayOfQuantityCells = Array.from(this.quantityCells);
        var quantityArray = arrayOfQuantityCells.map(QuantityArrayMapper.DOMObjectValue);
        return quantityArray;
    }
}

QuantityArrayMapper.DOMObjectValue = function (DOMObject)
{
    return DOMObject.value;
}

function ArrayAnalyser(array) {
    this.array = array;
}

ArrayAnalyser.prototype.containsAllZeros = function ()
{
    var array = this.array;
    for (var i = 0; i < array.length; i++) {
        if (array[i] != 0) {
            return false;
        }
    }
    return true;
}

ArrayAnalyser.prototype.containsNegativeValues = function ()
{
    var array = this.array;
    for (var i = 0; i < array.length; i++) {
        if (array[i] < 0) {
            return true;
        }
    }
    return false;
}

ArrayAnalyser.prototype.arrayOutOfRange = function (max)
{
    var array = this.array;
    for (var i = 0; i < array.length; i++) {
        if (array[i] > max) {
            return true;
        }
    }
    return false;
}

function ClientValidateNotZeros(sender, args)
{
    var quantityArray = new QuantityArrayMapper().mapFromRepeater();
    var arrayAnalyser = new ArrayAnalyser(quantityArray);
    args.IsValid = !arrayAnalyser.containsAllZeros();
    //if (!args.IsValid) {
    //    console.log("client not zeros used");
    //}
}

function ClientValidateNoNegatives(sender, args)
{
    var quantityArray = new QuantityArrayMapper().mapFromRepeater();
    var arrayAnalyser = new ArrayAnalyser(quantityArray);
    args.IsValid = !arrayAnalyser.containsNegativeValues();
    //if (!args.IsValid) {
    //    console.log("client no negatives used");
    //}
}

function ClientValidateInRange(sender, args)
{
    var quantityArray = new QuantityArrayMapper().mapFromRepeater();
    var arrayAnalyser = new ArrayAnalyser(quantityArray);
    args.IsValid = !arrayAnalyser.arrayOutOfRange(254);
    //if (!args.IsValid) {
    //    console.log("client in range used");
    //}
}

totalValueCell.innerHTML = "£" + 0.00.toFixed(2)
updateButton.addEventListener("click", updateClicked);







