namespace TotallyMoney.TrustPilotLinks.Web.Logic
{
    public class Result
    {
        public string CustName;
        public string CustEmail;
        public string OrderRef;
        public string Domain;
        public string UniqueLink;
        public string Subscriber;

        public Result(string custName, string custEmail, string orderRef, string domain, string uniqueLink, string subscriber)
        {
            CustName = custName;
            CustEmail = custEmail;
            OrderRef = orderRef;
            Domain = domain;
            UniqueLink = uniqueLink;
            Subscriber = subscriber;
        }

    }
}
