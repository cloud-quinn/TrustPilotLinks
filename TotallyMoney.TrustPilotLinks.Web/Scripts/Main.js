
$(document).ready(function () {
    $("#aboutDomain").hide();
    $("#aboutSecretKey").hide();
    $("#aboutOrderID").hide();
    $("#copyLink").hide();
    var offset = $(".showAboutSecretKey").offset;


    $("#accordion").accordion({
        heightStyle: "content",
        //set localStorage for current index on activate event
        activate: function (event, ui) {
            localStorage.setItem("accIndex", $(this).accordion("option", "active"));
        },
        active: parseInt(localStorage.getItem("accIndex"))
    });



$("#copy").click(function () {
    $("#uniqueLink").select();
    var copied = document.execCommand('copy');
});

$(".showAboutDomain").click(function () {
    if ($("#aboutDomain").css("display") === "none") {
        if (offset !== $(this).offset()) {
            offset = $(this).offset();
            $("#aboutDomain").css({ "top": offset.top + 20, "left": offset.left + 20 });
        }
        $("#aboutDomain").show();
    }
    else {
        $("#aboutDomain").hide();
    }
});

$(".showAboutSecretKey").click(function () {
    if ($("#aboutSecretKey").css("display") === "none") {
        if (offset !== $(this).offset()) {
            offset = $(this).offset();
            $("#aboutSecretKey").css({ "top": offset.top + 20, "left": offset.left + 20 });
        }
        $("#aboutSecretKey").show();
    }
    else {
        $("#aboutSecretKey").hide();
    }
});

$(".showAboutOrderID").click(function () {
    if ($("#aboutOrderID").css("display") === "none") {
        if (offset !== $(this).offset()) {
            offset = $(this).offset();
            $("#aboutOrderID").css({ "top": offset.top + 20, "left": offset.left + 20 });
        }
        $("#aboutOrderID").show();
    }
    else {
        $("#aboutOrderID").hide();
    }
});

$("#copy").hover(function () {
    if ($("#copyLink").css("display") === "none") {
        if (offset !== $(this).offset()) {
            offset = $(this).offset();
            $("#copyLink").css({ "top": offset.top + 20, "left": offset.left + 20 });
        }
        $("#copyLink").show();
    }
    else {
        $("#copyLink").hide();
    }
});

});