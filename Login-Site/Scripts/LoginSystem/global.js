var grecaptcha;
function acceptCookies() {
    $.ajax({
        url: "/umbraco/surface/Cookies/Accept",
        dataType: "text",
        type: "GET",
        success: function () {
            $("#Cookies").fadeOut(500);
        }
    });
}
function refreshScripts() {
    if ($("#Recaptcha").length) {
        grecaptcha.render("Recaptcha", { sitekey: $("#Recaptcha").data("sitekey"), theme: $("#Recaptcha").data("theme") });
    }
}
$(document).ready(function () {
    refreshScripts();
});
