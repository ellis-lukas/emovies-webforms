const updateButton = document.querySelector(".update__button");
const totalValueCell = document.querySelector(".total__cell--value");
const movieList = document.querySelectorAll(".table-row");
const body = document.querySelector("body");

function prepareMovieTable() {
    updateTotal();
}

function updateTable() {
    updateTotal();
}

function updateTotal() {
    totalValueCell.innerHTML = "£" + calculateTotal().toFixed(2);
}

function calculateTotal() {
    var total = 0.0;
    movieList.forEach((movie) => {
        total += individualMovieTotal(movie);
    });
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

prepareMovieTable();

updateButton.addEventListener("click", updateTable);






