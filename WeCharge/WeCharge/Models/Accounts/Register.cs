using System;
namespace WeCharge.Models.Accounts
{
	public class Register
	{
        //person information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //vehicle information
        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public string ChargerType { get; set; }

    }
}

