using Microsoft.EntityFrameworkCore;
using SalesManagementApI.Data_Access;
using SalesManagementApI.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApI.Logic
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly AppDbContext _dbContext;
        public CustomerRepo (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Create(CustomerModel model)
        {
            await _dbContext.Customers.AddAsync(model);
            int res = await _dbContext.SaveChangesAsync();
            if (res > 0)
            {
                return 1;
            }
            return 0;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomer()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<CustomerModel> GetById(int id)
        {
            var custmr = await _dbContext.Customers.FindAsync(id);
            return custmr;
        }

        public Task<int> Update(CustomerModel model)
        {
            throw new NotImplementedException();
        }
    }
}
