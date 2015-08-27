using System.ComponentModel.DataAnnotations;

namespace TotallyMoney.TrustPilotLinks.Web.Models
{
    public class InputViewModel
    {
        [Display(Name = "Your customer's full name")]
        [Required(ErrorMessage = "Customer name required")]
        [MinLength(1, ErrorMessage = "Customer name must be 2 characters or longer")]
        [MaxLength(100, ErrorMessage = "Customer name must be shorter than 100 characters")]
        [RegularExpression(@"^[a-zA-Z\s-]+$",
            ErrorMessage = "Please check customer name and remove any special characters.")]
        public string CustName { get; set; }

        [Display(Name = "Your customer's e-mail address")]
        [Required(ErrorMessage = "E-mail address required")]
        [MaxLength(100, ErrorMessage = "E-mail address must be shorter than 100 characters")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            ErrorMessage = "Please enter a valid e-mail address.")]
        public string CustEmail { get; set; }

        [Display(Name = "Your customer's unique ID")]
        [Required(ErrorMessage = "Unique ID required")]
        [MaxLength(100, ErrorMessage = "Unique ID must be shorter than 100 characters")]
        public string OrderRef { get; set; }

        [Display(Name = "Your domain name on Trustpilot")]
        [Required(ErrorMessage = "Domain name required")]
        [MaxLength(100, ErrorMessage = "Domain name must be shorter than 100 characters")]
        public string Domain { get; set; }

        [Display(Name = "Your secret key")]
        [Required(ErrorMessage = "Secret key required")]
        public string Key { get; set; }
    }
}