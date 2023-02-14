using SalesManagementApI.Modals;
using SalesManagementApI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApI.Logic
{
    public interface IProductRepo
    {
        Task<IEnumerable<ProductModel>> GetAllProduct();
        Task<ProductModel> GetById(int id);
        Task<int> Create(ProductViewModel model);
        Task<int> CreateOrder(OrderCreateViewModel model);
        Task<int> Delete(int id);
        Task<int> Update(ProductViewModel model);
        IEnumerable<OrderDetails> OrderDetail(int id);
    }
}
