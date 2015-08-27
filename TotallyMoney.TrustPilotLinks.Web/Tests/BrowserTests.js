casper.test.begin('TrustPilot form test', 18, function suite(test) {

    //casper.start("http://localhost:2513/Home/Index");
    casper.start("http://192.168.1.243:1402");
    casper.viewport(1280, 1024);

    casper.then(function () {
        // Does page load?
        test.assertHttpStatus(200, 'TrustPilot form loads');
        test.assertTextExists('Generate unique links', 'Heading appears - Generate unique links');
        this.click('h3[id="ui-id-1"]');
    });

    casper.then(function () {
        //can we see an error if we don't upload a valid file?                
        this.wait(1000, function () {
        this.click('button#downloadFile'); 
   		});
        this.wait(1000, function () {
            this.capture('Images/no-file-uploaded.png');
            test.assertVisible('p.error');
            test.assertTextExists('Please upload a valid .csv file of customer data', 'Correct error appears - "Please upload a valid .csv file of customer data"');
        });
    });

    casper.then(function () {
        //can we show manual input fields?
        this.click('h3[id="ui-id-3"]');
        test.assertVisible('input#Domain');
        this.wait(1000, function () {
        this.capture('Images/manual-input-fields.png');
        });
    });

    casper.then(function () {
        //can we show hints?
        this.click('a.showAboutDomain');
        test.assertVisible('small#aboutDomain');
        this.click('a.showAboutSecretKey');
        test.assertVisible('small#aboutSecretKey');
        this.wait(1000, function () {
        this.capture('Images/hints.png');
        });
    });

    casper.then(function () {
        //can we hide hints?
        this.click('a.showAboutDomain');
        test.assertNotVisible('small#aboutDomain');
        this.click('a.showAboutSecretKey');
        test.assertNotVisible('small#aboutSecretKey');
    });

    casper.then(function () {
        //fill in fields
        this.evaluate(function () {
            document.getElementById('Domain').value = "totallymoney.com";
            document.getElementById('Key').value = "mykey12";
            document.getElementById('CustName').value = "John Doe";
            document.getElementById('CustEmail').value = "email@email.com";
            document.getElementById('OrderRef').value = "1234";
        });
    });

    casper.then(function () {
        this.wait(1000, function () {
            //are fields filled in?
            this.test.assertEval(function () {
                return document.getElementById('Domain').value === "totallymoney.com";
            }, 'Domain filled in');

            this.test.assertEval(function () {
                return document.getElementById('Key').value === "mykey12";
            }, 'Secret key filled in');

            this.test.assertEval(function () {
                return document.getElementById('CustName').value === "John Doe";
            }, 'Customer name filled in');

            this.test.assertEval(function () {
                return document.getElementById('CustEmail').value === "email@email.com";
            }, 'Customer e-mail filled in');

            this.test.assertEval(function () {
                return document.getElementById('OrderRef').value === "1234";
            }, 'Order ID filled in');
        });
    });

    casper.then(function () {
        //can we get the unique link for the customer data we just entered?
        this.click('button#getLink');
        this.wait(1000, function () {
            this.test.assertEval(function () {
                return document.getElementById('uniqueLink').value !== " ";
            }, 'A current link appears on click');
            this.test.assertEval(function () {
                return document.getElementById('uniqueLink').value === "http://www.trustpilot.com/evaluate/totallymoney.com?a=1234&b=ZW1haWxAZW1haWwuY29t&c=John%20Doe&e=b232dc87ad2a699763720a29f5b3db2df6f80dfd";
            }, 'Correct current link generated on click');
            this.capture('Images/current-link.png');
        });
    });

    casper.then(function () {
        //can we clear the unique fields in order to add another customer?
        this.click('button#addCustomer');
        this.wait(1000, function () {
            this.test.assertEval(function () {
                return document.getElementById('CustName').value === "";
            }, 'Customer name cleared on click of "Add another customer"');
            this.capture('Images/add-another-customer.png');
        });
    });

    casper.then(function () {
        //can we hide manual inputs?
        this.click('h3[id="ui-id-1"]')
        this.wait(1000, function () {
        test.assertNotVisible('input#Domain')
        });
    });

    casper.run(function () {
        test.done();
    });
});