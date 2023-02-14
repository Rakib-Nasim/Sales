using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApI.Modals
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        public virtual IEnumerable<ProductCustomer> ProductCustomer { get; set; }
    }
}
