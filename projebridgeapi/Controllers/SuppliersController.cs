using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projebridgeapi.Models;
using projectbridgeapi.Models;

namespace projebridgeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public SuppliersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetSuppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            var values = await context.Suppliers.ToListAsync();
            return Ok(values);
        }

        [HttpGet("GetSupplierById/{id}")]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var value = await context.Suppliers.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier(Supplier supplier)
        {
            await context.Suppliers.AddAsync(supplier);
            await context.SaveChangesAsync();

            return Ok("Tedarikçi başarıyla eklendi.");
        }

        [HttpPut("UpdateSupplier/{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, Supplier supplier)
        {
            var value = await context.Suppliers.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            value.SupplierName = supplier.SupplierName;
            value.Phone = supplier.Phone;
            value.City = supplier.City;

            await context.SaveChangesAsync();

            return Ok("Tedarikçi başarıyla güncellendi.");
        }

        [HttpDelete("DeleteSupplier/{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var value = await context.Suppliers.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            context.Suppliers.Remove(value);
            await context.SaveChangesAsync();

            return Ok("Tedarikçi başarıyla silindi.");
        }
    }
}