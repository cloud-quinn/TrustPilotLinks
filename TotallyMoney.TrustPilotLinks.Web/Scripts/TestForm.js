$(document).ready(function () {
    var inputs = [
	{ Domain: 'totallymoney.com', Key: 'secretkey15', CustName: "Jane Doe", CustEmail: 'jane@email.co.uk', OrderRef: 'TM865' },
	{ Domain: 'mydomain.co.uk', Key: 'mys3cr3tk3y', CustName: "Test User", CustEmail: 'test@example.com', OrderRef: '202004' },
    { Domain: 'mysite.net', Key: 'mykey12', CustName: "John Doe", CustEmail: 'email@email.com', OrderRef: '1234' }
    ];

    $("#fillFields").click(function () {
        var random = Math.floor((Math.random() * inputs.length));
        console.log(random);
        $("#Domain").val(inputs[random].Domain);
        $("#Key").val(inputs[random].Key);
        $("#CustName").val(inputs[random].CustName);
        $("#CustEmail").val(inputs[random].CustEmail);
        $("#OrderRef").val(inputs[random].OrderRef);
    });
});
