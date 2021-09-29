
    var loggedInMobile = '';

    $(document).ready(function () {

        if (loggedInMobile == '') {
            $('#scrollable-auto-tabpanel-0').show();
            $('#scrollable-auto-tabpanel-1').hide();
        }
        else {

            $('#scrollable-auto-tabpanel-0').hide();
            $('#scrollable-auto-tabpanel-1').show();
        }

    });


    function SendCodeToMobile() {

        debugger;

        var mobile = $('#loginmobile').val();

        let customer = {
            Mobile: mobile
        };

        var settings = {
            "url": "https://localhost:5001/Customer/SendActivationCodeToMobile",
            "method": "POST",
            "timeout": 0,
            "headers": {
                "Content-Type": "application/json"
            },
            "data": JSON.stringify(orderObj),
        };

        $.ajax(settings)({
            statusCode: {
                400: function (res) {
                    alert(JSON.stringify(res));
                },
                200: function (res) {
                    alert(JSON.stringify(res));
                }
            }
        });


        //$.ajax(settings).done(function (response) {
        //    console.log(response);
        //});
    }


