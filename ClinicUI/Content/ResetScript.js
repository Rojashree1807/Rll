
document.addEventListener("DOMContentLoaded", function () {
    const passwordInput = document.getElementById("pass1");
    const showPasswordIcon = document.getElementById("showPasswordIcon");

    showPasswordIcon.addEventListener("click", function () {
        if (passwordInput.type === "password") {
            passwordInput.type = "text";
            showPasswordIcon.textContent = "👁️";
        } else {
            passwordInput.type = "password";
            showPasswordIcon.textContent = "👁️‍🗨️";
        }
    });
});


document.addEventListener("DOMContentLoaded", function () {
    const passwordInput1 = document.getElementById("pass2");
    const showPasswordIcon1 = document.getElementById("showPasswordIcon1");

    showPasswordIcon1.addEventListener("click", function () {
        if (passwordInput1.type === "password") {
            passwordInput1.type = "text";
            showPasswordIcon1.textContent = "👁️";
        } else {
            passwordInput1.type = "password";
            showPasswordIcon1.textContent = "👁️‍🗨️";
        }
    });
});