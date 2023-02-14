using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApI.Modals
{
    public class ProductCustomer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int? ProductId{ get; set; }
        public virtual ProductModel Product { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public virtual CustomerModel Customer { get; set; }

        public int? Unit { get; set; }
        public int? TotalPrice { get; set; }

    }
}
