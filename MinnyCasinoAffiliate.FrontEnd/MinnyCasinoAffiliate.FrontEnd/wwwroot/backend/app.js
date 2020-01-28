$(".passtoggle").click(function () {
    var passwordInput = $("#password");
    $(this).toggleClass("uil-eye uil-eye-slash");
    if (passwordInput.attr("type") == "password") {
        passwordInput.attr("type", "text");
    } else {
        passwordInput.attr("type", "password");
    }
});