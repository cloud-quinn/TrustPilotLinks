$(document).ready(function () {
    $("#aboutDomain").hide();
    $("#aboutSecretKey").hide();
    var offset = $(".showAboutSecretKey").offset;


    $(window).load(function () {
        var needToShow = 0;
        $("span.field-validation-error").each(function () {
            needToShow++;
        });

        $("input").each(function () {
            var value = $(this).val();
            if (value != undefined && value.length > 0) {
                needToShow++;
            }
        });

        if (needToShow > 0) {
            $(".manual").show();
        }
        else {
            $(".manual").hide();
        }
    });

    $("#addCustomer").click(function () {
        var n = 0;
        $("input").each(function () {
            n++;
            if (n > 3) {
                $(this).val("");
            }
        });
    });

    $("#manualInput").click(function () {
        if ($(".manual").css("display") == "none") {
            $(".manual").show();
            $(".fileRequirements").hide();
        }
        else {
            $(".manual").hide();
            $(".fileRequirements").show();
        }
    });

    $("#copy").click(function () {
        $("#uniqueLink").select();
        var copied = document.execCommand('copy');
    });

    $(".showAboutDomain").click(function () {
        if ($("#aboutDomain").css("display") == "none") {
            if (offset != $(this).offset()) {
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
        if ($("#aboutSecretKey").css("display") == "none") {
            if (offset != $(this).offset()) {
                offset = $(this).offset();
                $("#aboutSecretKey").css({ "top": offset.top + 20, "left": offset.left + 20 });
            }
            $("#aboutSecretKey").show();
        }
        else {
            $("#aboutSecretKey").hide();
        }
    });
});