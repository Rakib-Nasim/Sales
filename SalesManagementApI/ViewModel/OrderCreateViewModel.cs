using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApI.ViewModel
{
    public class OrderCreateViewModel
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int ProductId { get; set; }
        public int? TotalPrice { get; set; }
        public int Unit { get; set; }
    }
}
