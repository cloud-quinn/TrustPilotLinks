using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotallyMoney.TrustPilotLinks.Web.Logic
{
    public class Result
    {
        public string CustName;
        public string CustEmail;
        public string OrderRef;
        public string Domain;
        public string UniqueLink;

        public Result(string custName, string custEmail, string orderRef, string domain, string uniqueLink)
        {
            CustName = custName;
            CustEmail = custEmail;
            OrderRef = orderRef;
            Domain = domain;
            UniqueLink = uniqueLink;
        }

    }
}
