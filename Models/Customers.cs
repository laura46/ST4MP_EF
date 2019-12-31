using System;
using System.Collections.Generic;

namespace ST4MPCRM.Models
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
