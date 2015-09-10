using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using TotallyMoney.TrustPilotLinks.Web.Contracts.Orchestrators;
using TotallyMoney.TrustPilotLinks.Web.Logic;
using TotallyMoney.TrustPilotLinks.Web.Models;

namespace TotallyMoney.TrustPilotLinks.Web.Orchestrators
{
    public class InputOrchestrator : IOrchestrator
    {
             public ActionResult GetIndexResult()
             {                          
                 return new ViewResult
                 {
                     ViewName = "Index",
                 };
             }

        
        public ActionResult GetLink(HttpPostedFileBase dataFile)
        {
            throw new NotImplementedException();
        }

        public ActionResult GetLinkManual(string submitType, InputViewModel input)
        {
            throw new NotImplementedException();
        }


/*             public System.Threading.Tasks.Task<ActionResult> GetPostIndexResult(ControllerContext controllerContext, Models.InputViewModel model)
             {
                 throw new NotImplementedException();
             }*/
    }
}
