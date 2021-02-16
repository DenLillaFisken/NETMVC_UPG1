// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("sub_btn").disabled = true;
var counter = [false, false, false, false, false]
var validation = [false, false, false, false, false]
var users = []

//Validering av textfälten
document.getElementById('fname').addEventListener('keyup', () => {
    let value = document.getElementById('fname').value
    if (validateinputlenght(2, value) == true) {
        document.getElementById('fnameerror').innerText = ''
        changecolor(true, 'fname')
        counter[0] = true
        test()
    }
    else {
        document.getElementById('fnameerror').innerText = 'Namnet måste innehålla minst 2 bokstäver'
        changecolor(false, 'fname')
        counter[0] = false
        test()
    }
})

document.getElementById('lname').addEventListener('keyup', () => {
    let value = document.getElementById('lname').value
    if (validateinputlenght(2, value) == true) {
        document.getElementById('lnameerror').innerText = ''
        changecolor(true, 'lname')
        counter[1] = true
        test()
    }
    else {
        document.getElementById('lnameerror').innerText = 'Namnet måste innehålla minst 2 bokstäver'
        changecolor(false, 'lname')
        counter[1] = false
        test()
    }
})
document.getElementById('email').addEventListener('keyup', () => {
    let values = document.getElementById('email').value

    if (validateEmail(values) == true) {
        document.getElementById('emailerror').innerText = ''
        changecolor(true, 'email')
        counter[2] = true
        test()
    }
    else {
        document.getElementById('emailerror').innerText = 'Emailadressen är felaktig'
        changecolor(false, 'email')
        counter[2] = false
        test()
    }
})

document.getElementById('pass1').addEventListener('keyup', () => {
    let value = document.getElementById('pass1').value
    if (validatePassword(value) == true) {
        document.getElementById('pass1error').innerText = ''
        changecolor(true, 'pass1')
        counter[3] = true
        test()
    }
    else {
        document.getElementById('pass1error').innerText = 'Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters'
        changecolor(false, 'pass1')
        counter[3] = false
        test()
    }
})
document.getElementById('pass2').addEventListener('keyup', () => {
    let value1 = document.getElementById('pass1').value
    let value2 = document.getElementById('pass2').value

    if (validateEqual(value1, value2) == true) {
        document.getElementById('pass2error').innerText = ''
        changecolor(true, 'pass2')
        counter[4] = true
        test()
    }
    else {
        document.getElementById('pass2error').innerText = 'Lösenorden är inte identiska'
        changecolor(false, 'pass2')
        counter[4] = false
        test()
    }
})

document.getElementById('sub_btn').addEventListener('submit', () => {
    document.getElementById('fname').value = "";
    document.getElementById('lname').value = "";
    document.getElementById('email').value = "";
})
//visar/gömmer spara-knappen
let test = () => {
    //console.log("går in i test")
    for (var i = 0; i < 5; i++) {
        console.log(counter[i])
    }
    if (counter.includes(false)) document.getElementById("sub_btn").disabled = true
    else document.getElementById("sub_btn").disabled = false

}
const validateinputlenght = (refnr, input) => {
    if (input.length >= refnr) {
        return true
    }
    else return false
}
const validateEqual = (v1, v2) => {
    if (v1 == v2) {
        return true
    }
    else return false
}
const validateEmail = (email) => {
    var reEmail = /^[a-z0-9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/
    return reEmail.test(email.toLowerCase())
}
let changecolor = (validate, id) => {
    if (validate == true) document.getElementById(id).style.backgroundColor = "#E7E7E7";
    else document.getElementById(id).style.backgroundColor = "#FFDDDD";
}

let validatePassword = (input) => {
    
        //Validate lowercase letters
        var lowerCaseLetters = /[a-z]/g;
         if (input.match(lowerCaseLetters)) {
            validation[0] = true
        } else {
            validation[0] = false
        }
        // Validate capital letters
        var upperCaseLetters = /[A-Z]/g;
        if (input.match(upperCaseLetters)) {
            validation[1] = true
        } else {
            validation[1] = false
        }
        //Validate numbers
        var numbers = /[0-9]/g;
        if (input.match(numbers)) {
            validation[2] = true
        } else {
            validation[2] = false
        }
        //Validate non alphanumeric
        var numbers = /^[a-zA-Z0-9]+$/;
        if (input.match(numbers)) {
            validation[3] = false
        } else {
            validation[3] = true
        }
        //Validate length
        if (input.length >= 8) {
            validation[4] = true
        } else {
            validation[4] = false
        }
        if (validation.includes(false)) {
            return false
        }
        else {
            return true
        }
}

