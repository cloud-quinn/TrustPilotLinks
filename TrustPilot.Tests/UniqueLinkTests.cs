using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TotallyMoney.TrustPilot.UniqueLink;
using TotallyMoney.TrustPilotLinks.Web.Logic;

namespace TrustPilot.Tests
{
    internal class WhenISubmitOneCustomersDetails : GivenA<Generator>
    {
        private readonly Generator _g = new Generator();
        private readonly Encoding _e = Encoding.Default;
        private string _name;
        private string _email;
        private string _orderId;
        private string _domain;
        private string _key;
        private string _emailResult;
        private string _encodedName;
        private string _hashResult;
        private string _uniqueLink;
        private string _expectedUniqueLink;

        protected override void Given()
        {
            base.Given();
            _name = "John Doe";
            _email = "email@email.com";
            _orderId = "1234";
            _domain = "totallymoney.com";
            _key = "mykey12";
            _expectedUniqueLink =
                "http://www.trustpilot.com/evaluate/totallymoney.com?a=1234&b=ZW1haWxAZW1haWwuY29t&c=John%20Doe&e=b232dc87ad2a699763720a29f5b3db2df6f80dfd";
        }

        protected override void When()
        {
            base.When();
            _emailResult = _g.GetBase64(_email, _e);
            _encodedName = _g.GetUrlEncodedName(_name);
            _hashResult = _g.CalculateHash(_key, _email, _orderId);
            _uniqueLink = _g.GetUniqueLink(_domain, _orderId, _emailResult, _encodedName, _hashResult);
        }

        [Then]
        public void AValueIsReturned()
        {
            Assert.IsNotEmpty(_uniqueLink);
        }

        [Then]
        public void TheCorrectUniqueLinkIsReturned()
        {
            Assert.AreEqual(_expectedUniqueLink, _uniqueLink);
        }
    }


    internal class WhenISubmitMultipleCustomersDetails : GivenA<Generator, Result>
    {
        private readonly Generator _g = new Generator();
        private readonly Encoding _e = Encoding.Default;
        private List<Input> data = new List<Input>();
        private string _name;
        private string _email;
        private string _orderId;
        private string _domain;
        private string _key;
        private string _emailResult;
        private string _encodedName;
        private string _hashResult;
        private string _uniqueLink;
        private string[] _domains = { "totallymoney.com", "luma.co.uk", "marbles.com", "fluid.co.uk", " " };
        private string[] _keys = { "t19o15t19a1l12l12y23m13o15n14e5y23", "l12u20m13a1", "m13a1rb2l12e5s", "f6l12u20i9d4", " " };
        private string[] _expectedLinks = { "http://www.trustpilot.com/evaluate/luma.co.uk?a=1922&b=am9obkBoaXNlbWFpbC5jb20=&c=John%20Doe&e=badbe6d8ee3f93936c25e6c76ec454b2cdcacc85", "http://www.trustpilot.com/evaluate/fluid.co.uk?a=1004&b=amFuZUBoZXJlbWFpbC5jb20=&c=Jane%20Doe&e=5af3c9fc5479cdac1d76151034d227ced69a5071", "http://www.trustpilot.com/evaluate/totallymoney.com?a=5333&b=dG90YWxseW1vbmV5QGVtYWlsLmNvbQ==&c=Total%20E%20Money&e=51f4fb299a485db4b7618833121eb78dd545cbf0", "http://www.trustpilot.com/evaluate/luma.co.uk?a=9436&b=bHVtYWNhcmRAZW1haWwuY29t&c=Luma%20Card&e=2870c68049846087a4021e38602ca966ff630961", "http://www.trustpilot.com/evaluate/marbles.com?a=2087&b=bWFyYmxlc0BlbWFpbC5jb20=&c=Miss%20Marbles&e=e1c0f8536e5baeb93ec6256ebf71e9ac33ee0970" };
        private string[] _testLinks = new string[5];

        protected override void Given()
        {
            base.Given();
            data.Add(new Input("John Doe", "john@hisemail.com", "1922", "luma.co.uk"));
            data.Add(new Input("Jane Doe", "jane@heremail.com", "1004", "fluid.co.uk"));
            data.Add(new Input("Total E Money", "totallymoney@email.com", "5333", "totallymoney.com"));
            data.Add(new Input("Luma Card", "lumacard@email.com", "9436", "luma.co.uk"));
            data.Add(new Input("Miss Marbles", "marbles@email.com", "2087", "marbles.com"));
        }

        protected override void When()
        {
            base.When();
            int i = 0;
            _key = _keys[i];
            foreach (var d in data)
            {
                _name = d.CustName;
                _email = d.CustEmail;
                _orderId = d.OrderRef;
                _domain = d.Domain;
                for (var t = 0; t < _domains.Length; t++) {  
                if (_domain == _domains[t])
                {
                    _key = _keys[t];
                }
}
                _emailResult = _g.GetBase64(_email, _e);
                _encodedName = _g.GetUrlEncodedName(_name);
                _hashResult = _g.CalculateHash(_key, _email, _orderId);
                _uniqueLink = _g.GetUniqueLink(_domain, _orderId, _emailResult, _encodedName, _hashResult);
                if (i < _testLinks.Length) { 
                _testLinks[i] = _uniqueLink;
                i++;
                }
            }

        }

        [Then]
        public void TheValuesAreReturned()
        {
            Assert.IsNotEmpty(_testLinks);
        }

        [Then]
        public void TheCorrectUniqueLinksAreReturned()
        {
            for (var i = 0; i < _testLinks.Length; i++)
            {
                Assert.AreEqual(_expectedLinks[i], _testLinks[i]);
            }

        }
    }
}