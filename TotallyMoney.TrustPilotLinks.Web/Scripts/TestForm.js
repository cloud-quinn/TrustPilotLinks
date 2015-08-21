$(document).ready(function () {
    var inputs = [
	{ Domain: 'totallymoney.com', Key: 'secretkey15', CustName: "Jane Doe", CustEmail: 'jane@email.co.uk', OrderRef: 'TM865' },
	{ Domain: 'mydomain.co.uk', Key: 'mys3cr3tk3y', CustName: "Test User", CustEmail: 'test@example.com', OrderRef: '202004' },
    { Domain: 'mysite.net', Key: 'mykey12', CustName: "John Doe", CustEmail: 'email@email.com', OrderRef: '1234' },
    { Domain: 'thisdomain.net', Key: 's18e5c3r17e5t19', CustName: "Amy Smith", CustEmail: 'amy@example.co.uk', OrderRef: 'AS10001' },
    { Domain: 'thiswebsite.com', Key: 'k11e5y24y5e11k', CustName: "Bob Smith", CustEmail: 'bob@email.com', OrderRef: 'SMITH883' }
    ];

    $("#fillFields").click(function () {
        var random = Math.floor((Math.random() * inputs.length));
        $("#Domain").val(inputs[random].Domain);
        $("#Key").val(inputs[random].Key);
        $("#CustName").val(inputs[random].CustName);
        $("#CustEmail").val(inputs[random].CustEmail);
        $("#OrderRef").val(inputs[random].OrderRef);
    });
});
