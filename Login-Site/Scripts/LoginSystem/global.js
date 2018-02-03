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
//# sourceMappingURL=global.js.map