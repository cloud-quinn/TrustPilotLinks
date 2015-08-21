using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TotallyMoney.TrustPilot.UniqueLink
{
    public class Generator
    {
        public string GetBase64(string email, Encoding enc)
        {
            var byteEmail = enc.GetBytes(email);
            var base64Email = Convert.ToBase64String(byteEmail);
            return base64Email; //TODO: get real key from Trustpilot and read emails and orderIDs from CRM / spreadsheet
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