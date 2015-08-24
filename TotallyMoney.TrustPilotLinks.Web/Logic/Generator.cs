using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TotallyMoney.TrustPilotLinks.Web.Logic
{
    public class Generator
    {
        //we want to create a unique link in the format http://www.trustpilot.com/evaluate/[YOUR-DOMAIN-NAME]?a=[CUSTOMER-ORDER-ID]&b=[CUSTOMER-EMAIL-IN-BASE64]&c=[CUSTOMERS-NAME-ENCODED]&e=[HASH-OF-CUSTOMER-EMAIL-ORDER-ID-AND-SECRET-KEY]
        //for example: http:// www.trustpilot.com/evaluate/embed/mysite.com?a=tyu9ytyui&b=bGdoQHRydXN0cGlsb3QuY29t&c=john&e=13d1ca785caccf7d6c0cb7cc4e33fa71e812b9d9
        //for each customer to whom we want to send a link we need their full name, email address, order ID, domain name of site they used, and a secret key for that domain (provided by Trustpilot)
        //collecting this data for all customers in one .csv file is best, so all links can be generated and downloaded at once

        public string GetBase64(string email, Encoding enc)
        {
            var byteEmail = enc.GetBytes(email);
            var base64Email = Convert.ToBase64String(byteEmail);
            return base64Email; 
        }

        public string GetUrlEncodedName(string name)
        {
            var encodedName = HttpUtility.UrlPathEncode(name);
            return encodedName;
        }

        public string CalculateHash(string key, string email, string orderId)
        {
            var stringInput = key + email + orderId;
            var asciiEnc = Encoding.ASCII;
            var byteInput = new byte[50];
            byteInput = asciiEnc.GetBytes(stringInput);
            SHA1 sha = new SHA1CryptoServiceProvider();
            var result = sha.ComputeHash(byteInput);
            var hashResult = BitConverter.ToString(result); //returns "-" delimited string, e.g. "B2-32-DC-87-AD-2A-69-97-63-72-0A-29-F5-B3-DB-2D-F6-F8-0D-FD"
            var tidying = hashResult.Split('-').ToArray();
            var hashString = string.Join("", tidying);
            var hash = hashString.ToLower(); //returns tidy string, e.g. b232dc87ad2a699763720a29f5b3db2df6f80dfd
            sha.Dispose();
            return hash;
        }

        public string GetUniqueLink(string domain, string orderId, string base64Email, string encodedName, string hash)
        {
            var uniqueLink = "http://www.trustpilot.com" + "/evaluate/" + domain + "?a=" + orderId + "&b=" + base64Email + "&c=" + encodedName + "&e=" + hash;
            return uniqueLink;
        }
    }
}