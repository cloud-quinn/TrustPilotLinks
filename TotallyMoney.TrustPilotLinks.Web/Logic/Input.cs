namespace TotallyMoney.TrustPilotLinks.Web.Logic
{
    public class Input
    {
        public string CustName;
        public string CustEmail;
        public string OrderRef;
        public string Domain;
        public string Key;

        public Input(string custName, string custEmail, string orderRef, string domain, string key = " ")
        {
            CustName = custName;
            CustEmail = custEmail;
            OrderRef = orderRef;
            Domain = domain;
            Key = key;
        }
    }
}