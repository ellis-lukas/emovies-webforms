var checkBox = document.querySelector(".form-row__checkbox");
var checkLabel = document.querySelector(".form-row__check-image");
var nameInput = document.querySelector(".form-row__cell--text");
var requiredNameValidator = document.querySelector(".form-row__required-field-validator");

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

//setInterval(function () { colorBorders() }, 100);

//function colorBorders() {
//    if (typeof (Page_Validators) !== 'undefined') {

//        //loop all the validators
//        for (var i = 0; i < Page_Validators.length; i++) {
//            var validator = Page_Validators[i];
//            var control = document.getElementById(validator.controltovalidate);

//            //check if the control actually exists
//            if (control != null) {

//                //if the validator is not valid color the border red, if it is valid return to default color
//                //elseif with rgb color is nessecary for preventing chrome dropdown blinking
//                if (!validator.isvalid) {
//                    control.style.borderColor = '#ff0000';
//                    control.value = errormsgforrequiredfield;
//                } else {
//                    control.style.borderColor = "";
//                }
//            }
//        }
//    }
//}