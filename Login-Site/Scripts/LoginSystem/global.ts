function acceptCookies() {
    $.ajax({
        url: "/umbraco/surface/Cookies/Accept",
        dataType: "text",
        type: "GET",
        success: () => {
            $("#Cookies").fadeOut(500);
        }
    });
}