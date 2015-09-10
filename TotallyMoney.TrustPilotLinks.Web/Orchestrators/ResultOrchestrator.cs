using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotallyMoney.TrustPilotLinks.Web.Contracts.Orchestrators;
using TotallyMoney.TrustPilotLinks.Web.Logic;
using TotallyMoney.TrustPilotLinks.Web.Models;

namespace TotallyMoney.TrustPilotLinks.Web.Orchestrators
{
    public class ResultOrchestrator : IOrchestrator
    {
        public ActionResult GetIndexResult()
        {
            return new ViewResult
            {
                ViewName = "Index",
            };
        }

        public IEnumerable<Result> GetHeaders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Result> UpdateResults(string name, string email, string reference, string domain, string link)
        {
            throw new NotImplementedException();
        }

        public FileStreamResult CreateFile(IEnumerable<Result> resultList)
        {
            throw new NotImplementedException();
        }
    }
}