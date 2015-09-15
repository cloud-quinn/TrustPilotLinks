using System.ComponentModel.DataAnnotations;

namespace TotallyMoney.TrustPilotLinks.Web.Models
{
    public class OptionsViewModel
    {

        [Display(Name = "Customer Names")]
        public bool ShowCustName { get; set; }

        [Display(Name = "Customer IDs")]
        public bool ShowCustId { get; set; }

        [Display(Name = "Sites customers visited")]
        public bool ShowDomain { get; set; }

        [Display(Name = "Subscriber *")]
        public bool ShowSubscriber { get; set; }
    }
}