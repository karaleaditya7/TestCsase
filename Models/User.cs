using System.Drawing;

namespace InflueriAutomation.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Password { get; set; }
        public string InvalidPassword { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserMobileNumber { get; set; }

        public string UserAdminRole { get; set; }

        public string PartnerName { get; set; }

    }
}