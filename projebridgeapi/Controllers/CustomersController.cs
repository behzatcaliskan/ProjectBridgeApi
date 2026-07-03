using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projebridgeapi.Models;
using projectbridgeapi.Models;

namespace projebridgeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CustomersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var values = await context.Customers.ToListAsync();
            return Ok(values);
        }

        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var value = await context.Customers.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();

            return Ok("Müşteri başarıyla eklendi.");
        }

        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            var value = await context.Customers.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            value.FullName = customer.FullName;
            value.Phone = customer.Phone;
            value.Email = customer.Email;

            await context.SaveChangesAsync();

            return Ok("Müşteri başarıyla güncellendi.");
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var value = await context.Customers.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            context.Customers.Remove(value);
            await context.SaveChangesAsync();

            return Ok("Müşteri başarıyla silindi.");
        }
    }
}