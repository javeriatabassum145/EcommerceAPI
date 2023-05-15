using EcommerceCRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            if (_dbContext.Brands == null)
            {
                return NotFound();
            }
            return await _dbContext.Brands.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands(int id)
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
    }
}
