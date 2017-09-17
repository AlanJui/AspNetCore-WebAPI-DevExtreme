using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class CustomerCustomerDemo
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public Customer Customer { get; set; }
        public CustomerDemographics CustomerType { get; set; }
    }
}
