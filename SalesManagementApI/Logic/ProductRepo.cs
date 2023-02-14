using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesManagementApI.Data_Access;
using SalesManagementApI.Modals;
using SalesManagementApI.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApI.Logic
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _dbContext;
        public ProductRepo (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Create(ProductViewModel model)
        {
            ProductModel product = new ProductModel();
            product.Id = model.Id;
            product.ProductCode = model.ProductCode;
            product.ProductName = model.ProductName;
            product.ProductPrice = model.ProductPrice;
            await _dbContext.Products.AddAsync(product);
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

        public async Task<IEnumerable<ProductModel>> GetAllProduct()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public Task<ProductModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ProductViewModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetails> OrderDetail(int id)
        {
            IEnumerable<OrderDetails> dataset = new List<OrderDetails>();
            using (var conn = new SqlConnection("Server=DESKTOP-IN1JKER;Database=SalesDB;Trusted_Connection=True;Encrypt=false"))
            {
                var peram = new
                {
                    id
                };

                dataset = conn.Query<OrderDetails>("GetOrder", param: peram, commandType: CommandType.StoredProcedure).ToList();
            }
            return dataset;
        }

        public async Task<int> CreateOrder(OrderCreateViewModel model)
        {
            

            ProductCustomer ProdCust = new ProductCustomer()
            { 
                Id=model.Id,
                ProductId = model.ProductId,
                CustomerId = model.CustomerId,
                TotalPrice = model.TotalPrice,
                Unit = model.Unit
            };
            await _dbContext.ProductCustomers.AddAsync(ProdCust);
            int result = await _dbContext.SaveChangesAsync();
            
            if (result > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
