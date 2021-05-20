using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_II.Models;

namespace Vidly_II.ViewModels
{
    public class CreateCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}