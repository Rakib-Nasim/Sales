using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApI.ViewModel
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Unit { get; set; }
        public int? TotalPrice { get; set; }


    }
}
