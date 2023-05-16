using EcommerceCRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandContext _dbContext;

        public BrandController(BrandContext dbContext){
            _dbContext= dbContext;
}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Brands>>> GetBrands()
        {
            if (_dbContext.Brands == null)
            {
                return NotFound();
            }
            return await _dbContext.Brands.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brands>>> GetBrands(int id)
        {
            if (_dbContext.Brands == null)
            {
                return NotFound();
            }
            return await _dbContext.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }
            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<Brands>> PostBrands(Brands brand)
        {
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrands), new {id = brand.ID},brand);

        }
    }
}
