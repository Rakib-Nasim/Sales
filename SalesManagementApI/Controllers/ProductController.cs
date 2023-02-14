using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesManagementApI.Logic;
using SalesManagementApI.Modals;
using SalesManagementApI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SalesManagementApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _ProductRepo;
        private readonly ICustomerRepo _CustomerRepo;
        private readonly IReportService _report;
        public ProductController(IProductRepo ProductRepo, ICustomerRepo CustomerRepo, IReportService report)
        {
            _ProductRepo = ProductRepo;
            _CustomerRepo = CustomerRepo;
            _report = report;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var productList = await _ProductRepo.GetAllProduct();
                return Ok(productList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreatProduct")]
        public async Task<IActionResult> CreatProduct([FromBody] ProductViewModel model)
        {
            try
            {
                var val = await _ProductRepo.Create(model);
                if (val == 1)
                {
                    return Ok(new { val });
                }
                 return Ok(new { val });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllOrder/{id}")]
        public  IEnumerable<OrderDetails> GetAllOrder(int id)
        {
            try
            {
              var order=  _ProductRepo.OrderDetail(id);
                return order;
            }
            catch (Exception)
            {
               throw;
            }
           
        }

        [HttpPost("CreatOrder")]
        public async Task<IActionResult> CreatOrder([FromBody] OrderCreateViewModel model)
        {
            try
            {
                var val = await _ProductRepo.CreateOrder(model);
                if (val == 1)
                {
                    return Ok( new {val} );
                }
                return Ok(new {val});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                var Customer = await _CustomerRepo.GetAllCustomer();
                return Ok(Customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetReport/{id}")]
        public async Task<IActionResult> GetReport(int id)
        {
            try
            {
                var reportFileByteString = _report.GenerateReportAsync(id);
                return File(reportFileByteString, MediaTypeNames.Application.Octet, "UserDetails.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
