using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TotallyMoney.TrustPilotLinks.Web.Logic;
using TotallyMoney.TrustPilotLinks.Web.Models;

namespace TotallyMoney.TrustPilotLinks.Web.Controllers
{
    public class HomeController : Controller
    {
        public DateTime DateTime = DateTime.Now;
        private List<Result> _results = new List<Result>();
        private string _uniqueLink;
        public List<Result> GetHeaders()
        {
            var header = new Result("Customer Name", "Customer E-mail", "Customer Reference", "Domain", "Unique Link");
            return new List<Result>() { header };
        }

        public List<Result> UpdateResults(string cName, string cEmail, string orderR, string domainUrl, string uLink)
        {
            var r = new Result(cName, cEmail, orderR, domainUrl, uLink);
            return new List<Result>() { r };
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            Session["ResultsList"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult GetLink(HttpPostedFileBase dataFile)
        {
            try
            {
                string filename = dataFile.FileName;
                string extension = Path.GetExtension(filename);

                if (dataFile != null && dataFile.ContentLength > 0 && extension == ".csv")
                {

                    var inputs = new List<Input>();
                    var results = new List<Result>(GetHeaders());
                    var uploadedBytes = new byte[dataFile.ContentLength];
                    dataFile.InputStream.Read(uploadedBytes, 0, dataFile.ContentLength);
                    var decodedString = Encoding.Default.GetString(uploadedBytes);
                    var linesInCsv = decodedString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var line in linesInCsv)
                    {
                        var components = line.Split(',');
                        char[] toTrim = { '\'', ' ' };
                        var name = components[0].Trim(toTrim);
                        var email = components[1].Trim(toTrim);
                        var orderNo = components[2].Trim(toTrim);
                        var domain = components[3].Trim(toTrim);
                        var key = components[4].Trim(toTrim);

                        inputs.Add(new Input(name, email, orderNo, domain, key) { CustName = name, CustEmail = email, OrderRef = orderNo, Domain = domain, Key = key });
                    }

                    foreach (Input input in inputs)
                    {
                        var g = new Generator();
                        var e = Encoding.Default;
                        var emailResult = Generator.GetBase64(input.CustEmail, e);
                        var encodedName = Generator.GetUrlEncodedName(input.CustName);
                        var hashResult = Generator.CalculateHash(input.Key, input.CustEmail, input.OrderRef);
                        _uniqueLink = Generator.GetUniqueLink(input.Domain, input.OrderRef, emailResult, encodedName, hashResult);

                        results.Add(new Result(input.CustName, input.CustEmail, input.OrderRef, input.Domain, _uniqueLink) { CustName = input.CustName, CustEmail = input.CustEmail, OrderRef = input.OrderRef, Domain = input.Domain, UniqueLink = _uniqueLink });
                    }

                    return CreateFile(results);

                }
            }
            catch (Exception exception)
            {
                var logFile = "D:/websites/TrustPilotLinks/Logs/" + DateTime.ToString(CultureInfo.InvariantCulture).Replace('/', '_').Replace(':', '_') + ".txt";
                System.IO.File.WriteAllText(logFile, DateTime + ": " + exception.Message);
            }
            ViewBag.Error = "Please upload a valid .csv file of customer data";
            return View("Index");

        }

        [HttpPost]
        public ActionResult GetLinkManual(string submitType, InputViewModel input)
        {
            try
            {
                
                var e = Encoding.Default; //returns UTF encoding 
                var g = new Generator();
                var emailResult = Generator.GetBase64(input.CustEmail, e);
                var encodedName = Generator.GetUrlEncodedName(input.CustName);
                var hashResult = Generator.CalculateHash(input.Key, input.CustEmail, input.OrderRef);
                _uniqueLink = Generator.GetUniqueLink(input.Domain, input.OrderRef, emailResult, encodedName, hashResult);

                var resultsList = (List<Result>)Session["ResultsList"];
                if (resultsList == null) resultsList = new List<Result>(GetHeaders());

                resultsList.AddRange(UpdateResults(input.CustName, input.CustEmail, input.OrderRef, input.Domain, _uniqueLink));
                Session["ResultsList"] = resultsList;
                _results = resultsList;

                if (submitType == "addCustomer")
                {     
                    ModelState.Clear();
                }

                if (submitType == "getCurrentLink")
                {
                    ViewBag.UniqueLink = _uniqueLink;
                }

                if (submitType == "downloadFile")
                {
                    return CreateFile(_results);
                }
            }
            catch (Exception exception)
            {
                var logFile = "D:/websites/TrustPilotLinks/Logs/" + DateTime.ToString(CultureInfo.InvariantCulture).Replace('/', '_').Replace(':', '_') + ".txt";
                System.IO.File.WriteAllText(logFile, DateTime + ": " + exception.Message);
            }

            return View("Index");
        }


        public FileStreamResult CreateFile(List<Result> resultList)
        {
            var data = "";

            foreach (var r in resultList)
            {
                var name = r.CustName.Trim();
                var email = r.CustEmail.Trim();
                var order = r.OrderRef.Trim();
                var link = r.UniqueLink.Trim();
                data += "'" + name + "', " + "'" + email + "', " + "'" + order + "', " + "'" + link + "'" + "\r\n";
            }

            var byteArray = Encoding.ASCII.GetBytes(data);
            var stream = new MemoryStream(byteArray);
            return File(stream, "text/plain", "TrustpilotCustomerUniqueLinks.txt");
        }
    }
}