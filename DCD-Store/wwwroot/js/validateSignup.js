function validate() {
    var flag1 = true;
    var email = document.signup.email.value;
    console.log(email);
    if (document.signup.username.value === "" || document.signup.username.value.length < 6) {
        document.getElementById("u_error").innerHTML = "Enter a valid username!!";
        flag1 = false;
    } else {
        document.getElementById("u_error").innerHTML = "";
        flag1 = true;
    }

    var flag2 = true;

    if (document.signup.age.value.length === 0) {
        document.getElementById("a_error").innerHTML = "Enter a valid age";
        flag2 = false;
    } else {
        document.getElementById("a_error").innerHTML = "";
        flag2 = true;
    }

    var flag3 = true;
    if (email === "") {
        document.getElementById("e_error").innerHTML = "Email Field cannot be empty!!";
        flag3 = false;
    } else if (!(email.indexOf("@") > 0 && (email.lastIndexOf(".") > email.indexOf("@") + 1) && (email.length > email.lastIndexOf(".") + 1))) {
        document.getElementById("e_error").innerHTML = "Please enter a valid Email!!";
        flag3 = false;
    } else {
        document.getElementById("e_error").innerHTML = "";
        flag3 = true;
    }

    var flag4 = true;

    if (document.signup.passwd.value === "") {
        document.getElementById("p_error").innerHTML = "Password cannot be empty!!";
        document.signup.passwd.focus();
        flag4 = false;
    } else if (document.signup.passwd.value.length < 6) {
        document.getElementById("p_error").innerHTML = "Cannot be less than 6 characters!!";
        document.signup.passwd.focus();
        flag4 = false;
    } else {
        document.getElementById("p_error").innerHTML = "";
        flag4 = true;
    }

    var flag5 = true;

    if (document.signup.phone.value === "" || document.signup.phone.value.length < 11) {
        document.getElementById("ph_error").innerHTML = "Enter valid phone number!!";
        flag5 = false;
    } else {
        document.getElementById("ph_error").innerHTML = "";
        flag5 = true;
    }

    var flag6 = true;

    if (document.signup.c_passwd.value === "") {
        document.getElementById("cp_error").innerHTML = "Cannot be empty!!";
        flag6 = false;
    } else if (document.signup.c_passwd.value !== document.signup.passwd.value) {
        document.getElementById("cp_error").innerHTML = "Password did not match!!";
        flag6 = false;
    } else {
        document.getElementById("cp_error").innerHTML = "";
        flag6 = true;
    }

    return (flag1 && flag2 && flag3 && flag4 && flag5 && flag6);
}

