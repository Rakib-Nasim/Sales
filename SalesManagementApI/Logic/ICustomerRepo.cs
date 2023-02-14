using SalesManagementApI.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApI.Logic
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<CustomerModel>> GetAllCustomer();
        Task<CustomerModel> GetById(int id);
        Task<int> Create(CustomerModel model);
        Task<int> Delete(int id);
        Task<int> Update(CustomerModel model);
    }
}
