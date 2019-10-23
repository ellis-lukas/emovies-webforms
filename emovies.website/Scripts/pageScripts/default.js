const updateButton = document.querySelector(".update__button");
const totalValueCell = document.querySelector(".total__cell--value");
const movieList = document.querySelectorAll(".table-row");

function calculateIndividualMovieTotal(movie) {
    var movieTotal = 0.0;
    var quantityCell = movie.querySelector(".table-row__cell--quantity");
    var priceCell = movie.querySelector(".table-row__price-bucket");
    var quantity;
    if (quantityCell.value == "") {
        quantity = 0;
    }
    else {
        quantity = parseInt(quantityCell.value);
    }
    var price = parseFloat(priceCell.value);
    movieTotal = quantity * price;
    return movieTotal;
}

function calculateTotal() {
    var total = 0.0;
    movieList.forEach((movie) => {
        total += calculateIndividualMovieTotal(movie);
    });
    return total;
}

function updateTotal() {
    totalValueCell.innerHTML = "£" + calculateTotal().toFixed(2);
}

updateButton.addEventListener("click", updateTotal);

updateTotal();