var checkBox = document.querySelector(".form-row__checkbox");
var checkLabel = document.querySelector(".form-row__checklabel");

var checkboxState = 0;

function checkboxChanged() {
    if (checkboxState === 0) {
        checkLabel.style.backgroundImage = "url('../Content/Images2/checkmark-black.png')";
        checkboxState = 1;
    }

    else {
        checkLabel.style.backgroundImage = "none";
        checkboxState = 0;
    }
}

checkBox.addEventListener("change", checkboxChanged);



